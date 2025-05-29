using CapstoneAPI.Context;
using CapstoneAPI.DTOs.Delivery;
using CapstoneAPI.Entities;
using CapstoneAPI.Helpers;
using CapstoneAPI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CapstoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderTrackingController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        private readonly IHubContext<OrderTrackingHub> _hub;

        public OrderTrackingController(CapstoneDbContext context, IHubContext<OrderTrackingHub> hub)
        {
            _context = context;
            _hub = hub;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendUpdateAsync(int orderId, double userLat, double userLong)
        {
            //var estimatedMinutes = TrackingHelper.GetEstimatedMinutes(order.DriverLocationLat ?? 0, order.DriverLocationLong ?? 0, userLat, userLong);
            try
            {

                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == true && l.Id == orderId);
                if (order != null)
                {
                    if (string.IsNullOrEmpty(order.SignalRConnectionId))
                        return NotFound("Order or connection not found.");
                    order.DriverLocationLat = userLat;
                    order.DriverLocationLong = userLong;
                    _context.Update(order);
                    _context.SaveChanges();
                    var data = new
                    {
                        OrderId = order.Id,
                        DriverLocationLat = order.DriverLocationLat,
                        DriverLocationLong = order.DriverLocationLong
                    };
                    await _hub.Clients.Client(order.SignalRConnectionId).SendAsync("ReceiveTrackingUpdate", data);
                    return Ok("Order Status Updated");
                }

               
                return Ok("Wrong Order Information");
            }
            catch (FriendlyException ex)
            {
                return StatusCode(ex.ErrorCode, "\t" + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderTracking(int orderId)
        {
            try
            {
                var order = await _context.Orders.FindAsync(orderId);

                if (order == null)
                    return NotFound("Order not found");
                var location = await _context.Locations.FindAsync(order.LocationId);
                var driver = await _context.Clients.FindAsync(order.DeliveryEmployeeId);
                var dto = new OrderTrackingDto
                {
                    OrderId = order.Id,
                    Status = _context.LookupItems.Where(x => x.Id == order.StatusId).FirstOrDefault()?.Name, // You can fetch from DB if needed
                    EstimatedTime = "Will Update Time When Your Driver Leave The Restaurant",
                    DriverLocationLat = order.DriverLocationLat,
                    DriverLocationLong = order.DriverLocationLong,
                    LocationTitle = location?.LocationTitle,
                    DriverHero = driver?.FullName,
                    DriverId = driver?.Id,
                    DriverImage = "",
                    PhoneNumber = "+962" + driver?.PhoneNumber
                };
                if (order.StatusId == 202)
                {
                    dto.EstimatedTime = TrackingHelper.GetEstimatedMinutes((double)location.Lat, (double)location.Long, (double)order.DriverLocationLat, (double)order.DriverLocationLong) + " Min";
                }
                if(order.StatusId == 203)
                {
                    dto.EstimatedTime = "Delivery Completeed";
                }
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateConnectionId([FromBody] UpdateConnectionInput input)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == input.OrderId && o.IsCheckout==true);
            if (order == null)
                return NotFound("Order not found or not checked out.");

            order.SignalRConnectionId = input.NewConnectionId;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return Ok("Connection ID updated.");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateOrderStatus([FromQuery] int orderId, [FromQuery] int statusId)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == true && l.Id == orderId);
                if (order != null)
                {
                    if (order.StatusId < statusId && order.StatusId != 203)
                        order.StatusId = statusId;
                    else
                        return Ok("Wrong Status Please Check Order Flow");
                    _context.Update(order);
                    _context.SaveChanges();
                    return Ok("Order Status Updated");
                }
                return Ok("Wrong Order Information");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
