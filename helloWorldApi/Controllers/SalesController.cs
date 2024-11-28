using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using helloWorldApi.Data;
using helloWorldApi.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace helloWorldApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _uaserManager;


        public SalesController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _uaserManager = userManager;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            return await _context.Sales.ToListAsync();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(Guid id)
        {
            var sale = await _context.Sales.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }

        // GET: api/Sales/"2024-09-20"
        [HttpGet("GetByDate/{Date}")]
        public async Task<ActionResult<Sale>> GetSaleByDate(string Date)
        {
            var listSales = await _context.Sales.Where(s => s.SaleDate.Date.ToString() == Date).ToListAsync();

            if (listSales.Count <= 0)
            {
                return NotFound();
            }

            return Ok(listSales);
        }

        // GET: api/Sales/"2024-09-20 12:00:00"/"2024-09-30 12:00:00"
        [HttpGet("GetByInterval/{dateStart}/{dateEnd}")]
        public async Task<ActionResult<Sale>> GetSaleByInterval(DateTime dateStart, DateTime dateEnd)
        {
            var listSales = await _context.Sales.Where(s => s.SaleDate.Date >= dateStart && s.SaleDate <= dateEnd).ToListAsync();

            if (listSales.Count <= 0)
            {
                return NotFound();
            }

            return Ok(listSales);
        }

        // PUT: api/Sales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(Guid id, Sale sale)
        {
            if (id != sale.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            //buscar o curso no banco de dados
            var course = await _context.Courses.FindAsync(sale.CourseId);
            if (course == null) 
            { 
                return BadRequest(); 
            }
            sale.Course = course;

            //pegar o usuario logado
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return BadRequest();
            }
            var Appuser = await _context.Appusers.FirstOrDefaultAsync(u => u.User.Id.ToString() == userId);

            //atribuir usuario a venda
            sale.AppUserId = Appuser.AppuserId;
            sale.AppUser = Appuser;

            //colocar o valor do curso
            sale.SalePrice = course.Price;
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.SaleId }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(Guid id)
        {
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(Guid id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }
    }
}