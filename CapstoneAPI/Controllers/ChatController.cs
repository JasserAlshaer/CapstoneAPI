using CapstoneAPI.Context;
using CapstoneAPI.DTOs.Chats;
using CapstoneAPI.DTOs.Orders;
using CapstoneAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public ChatController(CapstoneDbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]/{orderId}")]
        public async Task<IActionResult> LoadChatConservation([FromRoute] int orderId,bool IsClient)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == true && l.Id == orderId);
                if (order != null)
                {
                    var conservation = await _context.Chats.FirstOrDefaultAsync(c => c.ClilentId == order.ClientId && c.EmployeeId == order.DeliveryEmployeeId);
                    if(conservation != null)
                    {
                       
                    }
                    else
                    {
                        conservation = new Chat()
                        {
                            IsActive = true,
                            CreatedBy = IsClient ? "Client" : "Driver",
                            CreationDate = DateTime.Now,
                            ClilentId = (int)order.ClientId,
                            EmployeeId = (int)order.DeliveryEmployeeId
                        };
                        await _context.AddAsync(conservation);
                        await _context.SaveChangesAsync();
                    }
                    return Ok(new
                    {
                        conservationId = conservation.Id,
                        IsActive = conservation.IsActive,
                        ClilentId = conservation.ClilentId,
                        EmployeeId = conservation.EmployeeId,
                        UpdateDate = conservation.UpdatedDate
                    });
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
        [HttpGet("[action]/{chatId}/{currentClientId}")]
        public async Task<IActionResult> LoadChatMessage([FromRoute] int chatId, [FromRoute] int currentClientId)
        {
            try
            {
                var chat = await _context.Chats.FirstOrDefaultAsync(l => l.Id == chatId);
                if (chat != null)
                {
                    var messages = from item in _context.Messages
                                   where item.ChatId == chatId
                                   orderby item.CreationDate
                                   select new
                                   {
                                       Id = item.Id,
                                       Text = item.Text,
                                       Date = item.CreationDate,
                                       SenderId = item.SenderId,
                                       IsClient = item.SenderId == currentClientId
                                   };
                    return Ok(await messages.ToListAsync());
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
        [HttpGet("[action]")]
        public async Task<IActionResult> CloseChat(int chatId)
        {
            try
            {
                var chat = await _context.Chats.FirstOrDefaultAsync(l => l.Id == chatId);
                if (chat != null)
                {
                    if (chat.IsActive == false)
                    {
                        return BadRequest("Chat Already Closed");
                    }
                    chat.IsActive = false;
                    chat.UpdatedBy = "Driver";
                    chat.UpdatedDate = DateTime.Now;

                    _context.Update(chat);
                    _context.SaveChanges();
                }
                return Ok("Wrong Chat Information");
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
        public async Task<IActionResult> SendMessage(CreateMessageInputDTO input)
        {
            try
            {
                var chat = await _context.Chats.FirstOrDefaultAsync(l => l.Id == input.ChatId);
                if (chat != null)
                {
                    if(chat.IsActive == false)
                    {
                        return BadRequest("Chat Closed");
                    }
                    chat.UpdatedBy = input.IsFromClient ? "Client" :"Driver";
                    chat.UpdatedDate = DateTime.Now;

                    _context.Update(chat);
                    _context.SaveChanges();

                    Message message = new Message()
                    {
                        ChatId = input.ChatId,
                        CreatedBy = input.IsFromClient ? "Client" : "Driver",
                        CreationDate = DateTime.Now,
                        IsActive = true,
                        SenderId = input.SenderId,
                        Text = input.Message
                    };
                    await _context.AddAsync(message);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return Ok("Wrong Chat Information");
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
    }
}
