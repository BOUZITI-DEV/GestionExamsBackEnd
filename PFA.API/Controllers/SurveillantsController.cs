using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PFA.Library.Models;
using PFA.Library.Services;

namespace PFA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveillantsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SurveillantsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Surveillants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Surveillant>>> GetSurveillants()
        {
            if (_context.Surveillants == null)
            {
                return NotFound();
            }
            return await _context.Surveillants.ToListAsync();
        }

		[HttpGet("LoginAsSurveillant/{login}/{password}")]
		public async Task<ActionResult<Surveillant>> LoginAsSurveillant(string login, string password)
		{
			if (_context.Surveillants == null)
			{
				return NotFound();
			}

			if (!await _context.Surveillants.AnyAsync(s => s.Login == login && s.Password == password))
			{
				return NotFound();
			}

			return await _context.Surveillants.SingleAsync(s => s.Login == login && s.Password == password);
		}

		// GET: api/Surveillants/5
		[HttpGet("{id}")]
        public async Task<ActionResult<Surveillant>> GetSurveillant(int id)
        {
          if (_context.Surveillants == null)
          {
              return NotFound();
          }
            var surveillant = await _context.Surveillants.FindAsync(id);

            if (surveillant == null)
            {
                return NotFound();
            }

            return surveillant;
        }

        // PUT: api/Surveillants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurveillant(int id, Surveillant surveillant)
        {
            if (id != surveillant.Id)
            {
                return BadRequest();
            }

            _context.Entry(surveillant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SurveillantExists(id))
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

        // POST: api/Surveillants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Surveillant>> PostSurveillant(Surveillant surveillant)
        {
          if (_context.Surveillants == null)
          {
              return Problem("Entity set 'DatabaseContext.Surveillants'  is null.");
          }
            _context.Surveillants.Add(surveillant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSurveillant", new { id = surveillant.Id }, surveillant);
        }

        // DELETE: api/Surveillants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurveillant(int id)
        {
            if (_context.Surveillants == null)
            {
                return NotFound();
            }
            var surveillant = await _context.Surveillants.FindAsync(id);
            if (surveillant == null)
            {
                return NotFound();
            }

            _context.Surveillants.Remove(surveillant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SurveillantExists(int id)
        {
            return (_context.Surveillants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
