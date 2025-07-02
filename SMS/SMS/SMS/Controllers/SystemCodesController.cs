using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Data;
using SMS.Shared.Models;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodes
        [HttpGet("all-system-codes")]
        public async Task<ActionResult<IEnumerable<SystemCode>>> GetAllSystemCodes()
        {
            return await _context.SystemCodes.ToListAsync();
        }

        // GET: api/SystemCodes/5
        [HttpGet("single-system-code/{id}")]
        public async Task<ActionResult<SystemCode>> GetSystemCodeById(int id)
        {
            var systemCode = await _context.SystemCodes.FindAsync(id);

            if (systemCode == null)
            {
                return NotFound();
            }

            return systemCode;
        }

        // PUT: api/SystemCodes/5
        [HttpPut("update-system-code/{id}")]
        public async Task<IActionResult> UpdateSystemCode(int id, SystemCode systemCode)
        {
            if (id != systemCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeExists(id))
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

        // POST: api/SystemCodes
        [HttpPost("add-system-code")]
        public async Task<ActionResult<SystemCode>> AddSystemCode(SystemCode systemCode)
        {
            _context.SystemCodes.Add(systemCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCodeById", new { id = systemCode.Id }, systemCode);
        }

        // DELETE: api/SystemCodes/5
        [HttpDelete("delete-system-code/{id}")]
        public async Task<IActionResult> DeleteSystemCode(int id)
        {
            var systemCode = await _context.SystemCodes.FindAsync(id);
            if (systemCode == null)
            {
                return NotFound();
            }

            _context.SystemCodes.Remove(systemCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeExists(int id)
        {
            return _context.SystemCodes.Any(e => e.Id == id);
        }
    }
}
