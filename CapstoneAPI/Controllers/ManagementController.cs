using CapstoneAPI.Context;
using CapstoneAPI.DTOs.Orders;
using CapstoneAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public ManagementController(CapstoneDbContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> LoadCartItems(int clientId)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == false && l.ClientId == clientId);
                if (order != null)
                {
                    var query = from item in _context.OrderItems
                                join product in _context.Items on item.ItemId equals product.Id
                                where item.CartId == order.Id
                                select new
                                {
                                    Id = item.Id,
                                    Name = product.Name,
                                    Description = product.Description,
                                    Rate = product.Rate,
                                    Review = product.Reviews,
                                    Price = product.Price,
                                    Image = product.Image,
                                    Quantity = item.Quantity,
                                    NetPrice = item.NetPrice,
                                    CartItem = item.Id,
                                    Notes = item.Note
                                };
                    return Ok(await query.ToListAsync());
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
        public async Task<IActionResult> AddItemToFavoriteList([FromQuery] int clientId, [FromQuery] int itemId)
        {
            try
            {
                var checkItem = await _context.WishLists.AnyAsync(l => l.ItemId == itemId && l.ClientId == clientId);
                if (checkItem)
                {
                    return BadRequest("Item Already Exisit");
                }
                WishList list = new WishList();
                list.ClientId = clientId;
                list.ItemId = itemId;
                list.CreatedBy = $"Client With Id {clientId}";
                list.CreationDate = DateTime.Now;

                _context.WishLists.Add(list);
                await _context.SaveChangesAsync();
                return Ok("Item Added Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveItemToFavoriteList(int Id)
        {
            try
            {
                var checkItem = await _context.WishLists.FirstOrDefaultAsync(l => l.Id == Id);
                if (checkItem != null)
                {
                    _context.WishLists.Remove(checkItem);
                    await _context.SaveChangesAsync();
                    return Ok("Item Removed Success");
                }
                return BadRequest("Item Not Exisit");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrReturnCart(int clientId)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(l => l.IsCheckout == false && l.ClientId == clientId);
                if (order != null)
                {
                    return Ok(order.Id);
                }
                Order cart = new Order();
                cart.ClientId = clientId;
                cart.IsCheckout = false;
                cart.IsActive = true;
                cart.CreatedBy = $"Client  With Id {clientId}";
                cart.CreationDate = DateTime.Now;

                await _context.AddAsync(cart);
                await _context.SaveChangesAsync();
                return Ok(cart.Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateItemIntoCart(CartUpdateDTO input)
        {
            try
            {
                //update
                var item = await _context.OrderItems.FirstOrDefaultAsync(l => l.Id == input.Id);
                
                if (item != null)
                {
                    var product = await _context.Items.FirstOrDefaultAsync(l => l.Id == item.ItemId);
                    if (product != null)
                    {
                        item.UpdatedDate = DateTime.Now;
                        item.UpdatedBy = $"Client";
                        item.Note = input.Note;
                        item.IsActive = true;
                        item.Quantity = input.Quantity;
                        item.NetPrice = input.Quantity * product.Price;
                        _context.Update(item);
                        await _context.SaveChangesAsync();
                        return Ok("Item Updated Successfully");
                    }
                    else
                    {
                        return BadRequest("No Existing Item To Modifiy");
                    }

                }
                else
                {
                    return BadRequest("No Existing Item To Modifiy");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddItemIntoCart(CartCreationDTO input)
        {
            try
            {

                    //create new item
                    var order = await _context.Orders.FirstOrDefaultAsync(l => l.Id == input.CartId);
                    var product = await _context.Items.FirstOrDefaultAsync(l => l.Id == input.ItemId);
                    if (order != null && product != null)
                    {
                        OrderItem item = new OrderItem();
                        item.CreationDate = DateTime.Now;
                        item.CreatedBy = $"Client";
                        item.Note = input.Note;
                        item.IsActive = true;
                        item.Quantity = input.Quantity;
                        item.NetPrice = input.Quantity * product.Price;
                        item.CartId = input.CartId;
                        item.ItemId = input.ItemId;
                        await _context.AddAsync(item);
                        await _context.SaveChangesAsync();
                        return Ok("Item Added Success");
                    }
                    else
                    {
                        return BadRequest("No Existing Item To Modifiy");
                    }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RemoveItemFromCart(int Id)
        {
            try
            {
                var checkItem = await _context.OrderItems.FirstOrDefaultAsync(l => l.Id == Id);
                if (checkItem != null)
                {
                    _context.Remove(checkItem);
                    await _context.SaveChangesAsync();
                    return Ok("Item Removed Success");
                }
                return BadRequest("Item Not Exisit");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
    }
}
