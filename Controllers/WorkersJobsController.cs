using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Job_Management_API.Data;
using Job_Management_API.Models;

namespace Job_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersJobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkersJobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkersJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkersJobs>>> GetWorkersJobs()
        {
            var Items = _context.WorkersJobs.Include(a => a.job).Include(a => a.worker);
            return await Items.ToListAsync();
        }

        // GET: api/WorkersJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkersJobs>> GetWorkersJobs(Guid id)
        {
            var workersJobs = await _context.WorkersJobs.FindAsync(id);

            if (workersJobs == null)
            {
                return NotFound();
            }

            return workersJobs;
        }

        // PUT: api/WorkersJobs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkersJobs(Guid id, WorkersJobs workersJobs)
        {
            if (id != workersJobs.workersJobsId)
            {
                return BadRequest();
            }

            _context.Entry(workersJobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkersJobsExists(id))
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

        // POST: api/WorkersJobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WorkersJobs>> PostWorkersJobs(WorkersJobs workersJobs)
        {
            _context.WorkersJobs.Add(workersJobs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkersJobs", new { id = workersJobs.workersJobsId }, workersJobs);
        }

        // DELETE: api/WorkersJobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkersJobs>> DeleteWorkersJobs(Guid id)
        {
            var workersJobs = await _context.WorkersJobs.FindAsync(id);
            if (workersJobs == null)
            {
                return NotFound();
            }

            _context.WorkersJobs.Remove(workersJobs);
            await _context.SaveChangesAsync();

            return workersJobs;
        }

        private bool WorkersJobsExists(Guid id)
        {
            return _context.WorkersJobs.Any(e => e.workersJobsId == id);
        }
    }
}
