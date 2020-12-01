using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Job_Management_API.Data;
using Job_Management_API.Models;
using Microsoft.AspNetCore.Razor.Language;

namespace Job_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workers>>> GetWorkers()
        {
            var Items = _context.Workers.Include(a => a.workersJobs);
            return await Items.ToListAsync();
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workers>> GetWorkers(Guid id)
        {
            var workers = await _context.Workers.FindAsync(id);

            if (workers == null)
            {
                return NotFound();
            }

            return workers;
        }

        // PUT: api/Workers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkers(Guid id, Workers workers)
        {
            if (id != workers.workerId)
            {
                return BadRequest();
            }

            _context.Entry(workers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkersExists(id))
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

        // POST: api/Workers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Workers>> PostWorkers(Workers workers)
        {
            _context.Workers.Add(workers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkers", new { id = workers.workerId }, workers);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Workers>> DeleteWorkers(Guid id)
        {
            var workers = await _context.Workers.FindAsync(id);
            if (workers == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(workers);
            await _context.SaveChangesAsync();

            return workers;
        }

        private bool WorkersExists(Guid id)
        {
            return _context.Workers.Any(e => e.workerId == id);
        }
    }
}
