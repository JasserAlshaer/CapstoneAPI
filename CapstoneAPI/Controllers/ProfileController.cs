using CapstoneAPI.Context;
using CapstoneAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public ProfileController(CapstoneDbContext context)
        {
            _context = context;
        }
        [HttpGet("load-notifications")]
        public async Task<IActionResult> GetNotifications()
        {
            try
            {
                var query = from item in _context.Notifications
                            where item.IsActive == true
                            select new
                            {
                                Id = item.Id,
                                Title = item.Title,
                                Description = item.Description,
                                IsRead = item.IsRead,
                                Date = item.CreationDate
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
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProfileDTO(int userId)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            var profile = await _context.Clients.Where(x => x.Id == userId)
                 .Select(x => new UserProfileDTO
                 {
                     ProfileId = x.Id,
                     Email = x.Email,
                     FullName = x.FullName,
                     Image = x.Image != null ? x.Image : "https://static-00.iconduck.com/assets.00/thinking-person-3-illustration-1131x2048-bhm4syl4.png",
                     Phone = x.PhoneNumber
                 }).FirstOrDefaultAsync();

            return Ok(profile);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> UpdateUserImage(int userId, string url)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            var profile = await _context.Clients.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (profile == null)
            {
                throw new Exception("No User Found With The Given Id");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    profile.Image = url;
                }
                _context.Update(profile);
                _context.SaveChanges();
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateUserProfile(UpdateUserProfileInputDTO input)
        {
            try
            {
                var profile = await _context.Clients.Where(x => x.Id == input.Id).FirstOrDefaultAsync();
                if (profile == null)
                {
                    throw new Exception("No User Found With The Given Id");
                }
                else
                {
                    if (input.Email != null)
                    {
                        profile.Email = input.Email;
                    }
                    if (input.FullName != null)
                    {
                        profile.FullName = input.FullName;
                    }
                    if (!string.IsNullOrWhiteSpace(input.Image))
                    { profile.Image = input.Image; }
                    if (!string.IsNullOrWhiteSpace(input.Phone))
                    { profile.PhoneNumber = input.Phone; }

                    _context.Update(profile);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
