using CapstoneAPI.Context;
using CapstoneAPI.DTOs.Delivery;
using CapstoneAPI.DTOs.Orders;
using CapstoneAPI.Entities;
using CapstoneAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public DeliveryController(CapstoneDbContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadNeareastDeliveryAddress(int clientId, float latatiude, float longatiude)
        {
            try
            {
                var query = await (from location in _context.Locations
                                   where location.ClientId == clientId
                                   select location).ToListAsync();

                query.Select(location => new
                {
                    ClientId = location.ClientId,
                    Latitude = location.Lat,
                    Longitude = location.Long,
                    Title = location.LocationTitle,
                    Distance = TrackingHelper.CalculateDistanceInKm(latatiude, longatiude, (double)location.Lat, (double)location.Long)
                })
                    .Where(d => d.Distance < 10)
                    .OrderBy(z => z.Distance);
                return Ok(query.FirstOrDefault());
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
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadDeliveyAddress(int clientId, float latatiude, float longatiude)
        {
            try
            {
                var query = await (from location in _context.Locations
                                   where location.ClientId == clientId
                                   select location).ToListAsync();

                var updatedQuery = query.Select(location => new
                {
                    Id = location.Id,
                    ClientId = location.ClientId,
                    Latitude = location.Lat,
                    Longitude = location.Long,
                    Title = location.LocationTitle,
                    Distance = TrackingHelper.CalculateDistanceInKm(latatiude, longatiude, (double)location.Lat, (double)location.Long)
                })
                    //.Where(d => d.Distance < 10)
                    .OrderBy(z => z.Distance)
                    .ToList();
                return Ok(updatedQuery);
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
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadPaymentMethods(int clientId)
        {
            try
            {
                var paymentsCards = from card in _context.PaymentCards
                                    join type in _context.LookupItems on card.CardTypeId equals type.Id
                                    where card.ClientId == clientId
                                    select new
                                    {
                                        CardId = card.Id,
                                        VirtualNumber = "************" + card.CardLatestNumber,
                                        Type = type.Name
                                    };
                return Ok(await paymentsCards.ToListAsync());
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
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadOrderInvoice(int orderId)
        {

            try
            {
                var invoice = await GetOrderInvoiceDTO(orderId);

                return Ok(invoice);
               
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

        [HttpPost("[action]")]
        public async Task<IActionResult> ApplyPromoCodeToOrder(PromoCodeToOrderInput input)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == false && l.Id == input.OrderId);
                if (order == null)
                    return StatusCode(204, "No Items In Cart");

                var coupon = await _context.Discounts
                    .FirstOrDefaultAsync(x => x.Code.ToLower() == input.PromoCode.ToLower() && x.IsActive);

                if (coupon == null)
                    return StatusCode(204, "No Match Coupon");

                var conditions = await _context.DiscountConditions
                    .Where(c => c.DiscountId == coupon.Id)
                    .ToListAsync();

                // Load required data (user + order subtotal)
                var user = await _context.Clients.FirstOrDefaultAsync(u => u.Id == order.ClientId);
                var orderSubtotal = await _context.OrderItems
                    .Where(x => x.CartId == input.OrderId)
                    .SumAsync(x => x.NetPrice);

                bool allConditionsMet = true;

                foreach (var condition in conditions)
                {
                    switch (condition.ConditionType)
                    {
                        case "OrderAmount":
                            if (!DiscountHelper.EvaluateCondition((float)orderSubtotal, condition.Operator, float.Parse(condition.Value)))
                                allConditionsMet = false;
                            break;
                    }

                    if (!allConditionsMet)
                        break;
                }

                if (allConditionsMet)
                {
                    order.CouponId = coupon.Id;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    return Ok("Discount Applied Successfully");
                }
                else
                {
                    return StatusCode(400, "This Promo Code does not apply to your current case.");
                }
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

        [HttpPost("[action]")]
        public async Task<IActionResult> SetOrderDeliveryLocation([FromQuery] int orderId, [FromQuery] int locationId)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == false && l.Id == orderId);
                if (order != null)
                {
                    var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == locationId);
                    if (location != null)
                    {
                        order.LocationId = location.Id;
                        _context.Update(order);
                        _context.SaveChanges();
                        return Ok("Location Saved");
                    }
                    else
                    {
                        return StatusCode(204, "No Match Coupon");
                    }

                }
                else
                {
                    return StatusCode(204, "No Items In Cart");
                }
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePaymentCard(CreatePaymentCardInputDTO input)
        {
            try
            {
                Random random = new Random();
                PaymentCard card = new PaymentCard()
                {
                    CreatedBy = "Client",
                    CreationDate = DateTime.Now,
                    ExpiryDate = DateOnly.Parse(input.ExpiryDate),
                    Balance = random.NextDouble() * (random.Next(50, 106)),
                    CardHolder = input.CardHolder,
                    CardLatestNumber = input.VisaNumber.Substring(12),
                    CardNumber = HashingHelper.HashValueWith512(input.VisaNumber),
                    CardTypeId = input.TypeId,
                    ClientId = input.ClientId,
                    Cvv = input.CVV,
                    IsActive = true,
                };
                _context.Add(card);
                _context.SaveChanges();
                return Ok("Payment Card Added Successfully");
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
        [HttpPost("[action]")]
        public async Task<IActionResult> CheckoutOrder(CheckoutOrderInputDTO input)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == false && l.Id == input.OrderId);
                if (order != null)
                {
                    Random random = new Random();
                    var assumedMinutes = random.Next(30, 45);
                    order.IsCheckout = true;
                    order.Date = DateTime.Now.AddMinutes(assumedMinutes);
                    order.DriverLocationLat = 31.9924448;
                    order.DriverLocationLong = 35.890178;
                    order.DeliveryEmployeeId = null; // will be modified
                    order.UpdatedDate = DateTime.Now;
                    order.UpdatedBy = "System";
                    order.StatusId = 200;
                    order.SignalRConnectionId = input.ConnectionId;
                    if (input.PaymentMethodId == 101) //credit card
                    {
                        if (order.PaymentCardId != null)
                        {
                            var creditCard = await _context.PaymentCards.FirstOrDefaultAsync(c => c.Id == order.PaymentCardId);
                            if (creditCard != null)
                            {
                                if (creditCard.ExpiryDate <= DateOnly.FromDateTime(DateTime.Now))
                                {
                                    return StatusCode(400, "Payment Card Was Expired");
                                }
                                var invoice = await GetOrderInvoiceDTO(input.OrderId);
                                if (creditCard.Balance < invoice.TotalPrice)
                                {
                                    return StatusCode(400, "Insufficient balance");
                                }
                                order.PaymentMethodId = 101;
                                order.PaymentCardId = creditCard.Id;
                                _context.Update(order);
                                _context.SaveChanges();
                                return Ok("Order Saved Successfully and Paid");
                            }
                            else
                            {
                                return StatusCode(400, "Wrong Payment Card Information");
                            }
                            
                        }
                        else
                        {
                            return StatusCode(400, "Wrong Payment Card Information");

                        }

                    }
                    else if (input.PaymentMethodId == 100) // cash
                    {

                        order.PaymentMethodId = 100;
                        order.PaymentCardId = null;
                        _context.Update(order);
                        _context.SaveChanges();
                        return Ok("Order Saved Successfully");
                    }
                    else
                    {
                        return StatusCode(400, "Wrong Payment Method");
                    }

                }
                else
                {
                    return StatusCode(204, "No Items In Cart");
                }
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
        [HttpPost("[action]")]
        public async Task<IActionResult> SetDeliveyAddress(DeliveryInputDTO input)
        {
            try
            {
                Location location = new Location();
                location.ClientId = input.ClientId;
                location.LocationTitle = input.Title;
                location.Description = input.Description;
                location.CreationDate = DateTime.Now;
                location.CreatedBy = "Client";
                location.Lat = input.Latatiude;
                location.Long = input.Longatiude;

                _context.Add(location);
                _context.SaveChanges();
                return Ok("Set Location Success");
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


        private async Task<OrderInvoiceDTO> GetOrderInvoiceDTO(int orderId)
        {
            var invoice = new OrderInvoiceDTO();

            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == false && l.Id == orderId);
                if (order != null)
                {
                    invoice.OrderId = order.Id;
                    var netOrderTotal = await _context.OrderItems.Where(x => x.CartId == orderId).SumAsync(x => x.NetPrice);
                    invoice.SubTotal = (float)netOrderTotal;
                    invoice.TotalPrice = invoice.SubTotal;
                    if (order.LocationId != null)
                    {
                        var location = await _context.Locations.FirstOrDefaultAsync(x => x.Id == order.LocationId);
                        invoice.Delivery = (float)((0.35) + (TrackingHelper.CalculateDistanceInKm(31.9924448, 35.890178, (double)location.Lat, (double)location.Long) * 0.22) + 0.17);
                        invoice.TotalPrice += invoice.Delivery;
                    }
                    if (order.CouponId != null)
                    {
                        var coupon = await _context.Discounts.FirstOrDefaultAsync(x => x.Id == order.CouponId && x.IsActive);

                        if (coupon != null)
                        {
                            var conditions = await _context.DiscountConditions
                                .Where(c => c.DiscountId == coupon.Id)
                                .ToListAsync();

                            bool allConditionsMet = true;

                            foreach (var condition in conditions)
                            {
                                switch (condition.ConditionType)
                                {

                                    case "OrderAmount":
                                        if (!DiscountHelper.EvaluateCondition((float)invoice.SubTotal, condition.Operator, float.Parse(condition.Value)))
                                            allConditionsMet = false;
                                        break;

                                        // Add more condition types as needed
                                }

                                if (!allConditionsMet)
                                    break;
                            }

                            if (allConditionsMet && coupon.DicountPercent.HasValue)
                            {
                                var discountValue = (invoice.SubTotal * coupon.DicountPercent.Value) / 100;
                                invoice.Discount = (float)discountValue;
                                invoice.TotalPrice = invoice.SubTotal - invoice.Discount + invoice.Delivery;
                                //invoice.CouponCode = coupon.Code;
                            }
                            else
                            {
                                invoice.TotalPrice = invoice.SubTotal + invoice.Delivery;
                            }
                        }
                    }

                    return invoice;
                }
                throw new Exception("Fill Your Cart With Item");
            }
            
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
