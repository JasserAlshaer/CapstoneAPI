using CapstoneAPI.Context;
using CapstoneAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public ShoppingController(CapstoneDbContext context)
        {
            _context = context;
        }

        [HttpGet("load-categories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var query = from item in _context.Categories
                            where item.IsActive == true
                            select new
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Image = item.Image
                            };
                return Ok(await query.ToListAsync());
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
        [HttpGet("load-discounts")]
        public async Task<IActionResult> GetDiscounts()
        {
            try
            {
                var query = from item in _context.Discounts
                            where item.IsActive == true
                            select new
                            {
                                Id = item.Id,
                                Name = item.Title,
                                Description = item.Description,
                                Code = item.Code,
                                Percent = item.DicountPercent,
                                Image = item.Image
                            };
                return Ok(await query.ToListAsync());
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
        [HttpGet("load-items")]
        public async Task<IActionResult> GetItems(string? keyword,int? categoryId, int pagesize = 10, int pageIndex = 1)
        {
            try
            {
                var query = (from item in _context.Items
                            where item.IsActive == true &&
                            (categoryId == null || item.CategoryId == categoryId) &&
                            (keyword == null || EF.Functions.Like(item.Name.ToLower(), $"%{keyword.ToLower()}%"))
                             select new
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Rate = item.Rate,
                                Price = item.Price,
                                Image = item.Image
                            }).Skip(pagesize*(pageIndex-1)).Take(pagesize);
                return Ok(await query.ToListAsync());
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
        [HttpGet("load-top-rated")]
        public async Task<IActionResult> GetTopRated(int? categoryId)
        {
            try
            {
                var query = (from item in _context.Items
                            where item.IsActive == true &&
                            (categoryId == null || item.CategoryId == categoryId)
                            orderby item.Rate descending
                            select new
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Rate = item.Rate,
                                Price = item.Price,
                                Image = item.Image
                            }).Take(8);
                return Ok(await query.ToListAsync());
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
        [HttpGet("load-top-recommened")]
        public async Task<IActionResult> GetTopRecommended(int? categoryId)
        {
            try
            {
                var query = (from item in _context.Items
                            where item.IsActive == true &&
                            (categoryId == null || item.CategoryId == categoryId)
                            orderby item.Rate descending
                            select new
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Rate = item.Rate,
                                Review = item.Reviews,
                                Price = item.Price,
                                Image = item.Image
                            }).Take(5);
                return Ok(await query.ToListAsync());
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
        [HttpGet("load-favorites")]
        public async Task<IActionResult> GetFavorites(int clientId)
        {
            try
            {
                var query = from item in _context.Items
                            join fav in _context.WishLists on item.Id equals fav.ItemId
                            where item.IsActive == true && fav.ClientId == clientId
                            select new
                            {
                                FavItemId = fav.Id,
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Rate = item.Rate,
                                Review = item.Reviews,
                                Price = item.Price,
                                Image = item.Image
                            };
                return Ok(await query.ToListAsync());
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
        [HttpGet("load-item-details")]
        public async Task<IActionResult> GetItemDetails(int Id)
        {
            try
            {
                var query = from item in _context.Items
                            join category in _context.Categories on item.CategoryId equals category.Id
                            where item.Id == Id
                            select new
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Description = item.Description,
                                Rate = item.Rate,
                                Review = item.Reviews,
                                Price = item.Price,
                                Image = item.Image,
                                te = item.CategoryId
                            };
                return Ok(await query.FirstOrDefaultAsync());
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
