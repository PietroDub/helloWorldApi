﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using helloWorldApi.Data;
using helloWorldApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace helloWorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppusersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppusersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appuser>>> GetAppusers()
        {
            return await _context.Appusers.ToListAsync();
        }

        // GET: api/Appusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appuser>> GetAppuser(Guid id)
        {
            var appuser = await _context.Appusers.FindAsync(id);

            if (appuser == null)
            {
                return NotFound();
            }

            return appuser;
        }

        // PUT: api/Appusers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppuser(Guid id, Appuser appuser)
        {
            if (id != appuser.AppuserId)
            {
                return BadRequest();
            }

            _context.Entry(appuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppuserExists(id))
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

        // POST: api/Appusers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Appuser>> PostAppuser(Appuser appuser)
        {
            _context.Appusers.Add(appuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppuser", new { id = appuser.AppuserId }, appuser);
        }

        // DELETE: api/Appusers/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppuser(Guid id)
        {
            var appuser = await _context.Appusers.FindAsync(id);
            if (appuser == null)
            {
                return NotFound();
            }

            _context.Appusers.Remove(appuser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppuserExists(Guid id)
        {
            return _context.Appusers.Any(e => e.AppuserId == id);
        }
    }
}
