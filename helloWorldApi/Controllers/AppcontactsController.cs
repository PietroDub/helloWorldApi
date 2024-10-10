using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using helloWorldApi.Data;
using helloWorldApi.Models;

namespace helloWorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppcontactsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppcontactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appcontacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appcontact>>> GetAppontacts()
        {
            return await _context.Appontacts.ToListAsync();
        }

        // GET: api/Appcontacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appcontact>> GetAppcontact(Guid id)
        {
            var appcontact = await _context.Appontacts.FindAsync(id);

            if (appcontact == null)
            {
                return NotFound();
            }

            return appcontact;
        }

        // PUT: api/Appcontacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppcontact(Guid id, Appcontact appcontact)
        {
            if (id != appcontact.AppcontactId)
            {
                return BadRequest();
            }

            _context.Entry(appcontact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppcontactExists(id))
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

        // POST: api/Appcontacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appcontact>> PostAppcontact(Appcontact appcontact)
        {
            _context.Appontacts.Add(appcontact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppcontact", new { id = appcontact.AppcontactId }, appcontact);
        }

        // DELETE: api/Appcontacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppcontact(Guid id)
        {
            var appcontact = await _context.Appontacts.FindAsync(id);
            if (appcontact == null)
            {
                return NotFound();
            }

            _context.Appontacts.Remove(appcontact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppcontactExists(Guid id)
        {
            return _context.Appontacts.Any(e => e.AppcontactId == id);
        }
    }
}
