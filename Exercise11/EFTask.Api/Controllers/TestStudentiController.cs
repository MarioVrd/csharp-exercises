using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFTask.Domain.Models;
using EFTask.Api.Models;

namespace EFTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestStudentiController : ControllerBase
    {
        private readonly StudentiContext _context;

        public TestStudentiController(StudentiContext context)
        {
            _context = context;
        }

        // GET: api/Studenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studenti>>> GetStudenti()
        {
            return await _context.Studenti.ToListAsync();
        }

        // GET: api/Studenti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studenti>> GetStudenti(int id)
        {
            var studenti = await _context.Studenti.FindAsync(id);

            if (studenti == null)
            {
                return NotFound();
            }

            return studenti;
        }

        // PUT: api/Studenti/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudenti(int id, Studenti studenti)
        {
            if (id != studenti.Id)
            {
                return BadRequest();
            }

            _context.Entry(studenti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentiExists(id))
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

        // POST: api/Studenti
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Studenti>> PostStudenti(Studenti studenti)
        {
            _context.Studenti.Add(studenti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudenti", new { id = studenti.Id }, studenti);
        }

        // DELETE: api/Studenti/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studenti>> DeleteStudenti(int id)
        {
            var studenti = await _context.Studenti.FindAsync(id);
            if (studenti == null)
            {
                return NotFound();
            }

            _context.Studenti.Remove(studenti);
            await _context.SaveChangesAsync();

            return studenti;
        }

        private bool StudentiExists(int id)
        {
            return _context.Studenti.Any(e => e.Id == id);
        }
    }
}
