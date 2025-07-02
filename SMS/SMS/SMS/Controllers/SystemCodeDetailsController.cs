using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Models;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemCodeDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodeDetails
        [HttpGet("system-code-details")]
        public async Task<ActionResult<IEnumerable<SystemCodeDetail>>> GetSystemCodeDetails()
        {
            return await _context.SystemCodeDetails.ToListAsync();
        }

        // GET: api/SystemCodeDetails/5
        [HttpGet("system-code-detail/{id}")]
        public async Task<ActionResult<SystemCodeDetail>> GetSystemCodeDetailById(int id)
        {
            var systemCodeDetail = await _context.SystemCodeDetails.FindAsync(id);

            if (systemCodeDetail == null)
            {
                return NotFound();
            }

            return systemCodeDetail;
        }

        // PUT: api/SystemCodeDetails/5
        [HttpPut("update-system-code-detail/{id}")]
        public async Task<IActionResult> UpdateSystemCodeDetail(int id, SystemCodeDetail systemCodeDetail)
        {
            if (id != systemCodeDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCodeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SystemCodeDetails
        [HttpPost("add-system-code-detail")]
        public async Task<ActionResult<SystemCodeDetail>> AddSystemCodeDetail(SystemCodeDetail systemCodeDetail)
        {
            _context.SystemCodeDetails.Add(systemCodeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCodeDetailById", new { id = systemCodeDetail.Id }, systemCodeDetail);
        }

        // DELETE: api/SystemCodeDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemCodeDetail(int id)
        {
            var systemCodeDetail = await _context.SystemCodeDetails.FindAsync(id);
            if (systemCodeDetail == null)
            {
                return NotFound();
            }

            _context.SystemCodeDetails.Remove(systemCodeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeDetailExists(int id)
        {
            return _context.SystemCodeDetails.Any(e => e.Id == id);
        }
    }
}
