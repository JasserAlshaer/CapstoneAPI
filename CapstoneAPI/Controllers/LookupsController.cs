using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneAPI.Helpers;
using System;
using CapstoneAPI.Context;
using CapstoneAPI.DTOs.Lookups;
using Microsoft.EntityFrameworkCore;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        private readonly CapstoneDbContext _context;
        public LookupsController(CapstoneDbContext context)
        {
            _context = context;
        }


        [HttpGet("lookups-by-type/{typeId}")]
        public async Task<IActionResult> GetLookups([FromRoute] int typeId)
        {
            try
            {
                var query = from item in _context.LookupItems
                            join type in _context.LookupTypes on item.TypeId equals type.Id
                            where type.Id == typeId
                            select new LookupItemDTO
                            {
                                Id = item.Id,
                                Name = item.Name,
                                ParentName = type.Name
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

        [HttpGet("list-country-codes")]
        public async Task<IActionResult> GetCountryCodes()
        {
            try
            {
                var query = from item in _context.CountryCodes
                            where item.IsActive == true
                            select new 
                            {
                                Id = item.Id,
                                Name = item.Iso,
                                flag = item.FlagUrl,
                                code = item.Code
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
    }
}
