using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthenticationAndPostingApi.Data;
using AuthenticationAndPostingApi.Models;

namespace AuthenticationAndPostingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportsController : ControllerBase
    {
        private readonly IncidentReportContext _context;

        public IncidentReportsController(IncidentReportContext context)
        {
            _context = context;
        }

        // GET: api/IncidentReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReport>>> GetIncidentReport()
        {
            return await _context.IncidentReport.ToListAsync();
        }

        // GET: api/IncidentReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentReport>> GetIncidentReport(int id)
        {
            var incidentReport = await _context.IncidentReport.FindAsync(id);

            if (incidentReport == null)
            {
                return NotFound();
            }

            return incidentReport;
        }

        // PUT: api/IncidentReports/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentReport(int id, IncidentReport incidentReport)
        {
            if (id != incidentReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(incidentReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentReportExists(id))
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

        // POST: api/IncidentReports
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<IncidentReport>> PostIncidentReport(IncidentReport incidentReport)
        {
            _context.IncidentReport.Add(incidentReport);
            await _context.SaveChangesAsync();

            string userId = User.Identity.GetUserId();
            incidentReport.UserId = userId;

            return CreatedAtAction("GetIncidentReport", new { id = incidentReport.Id }, incidentReport);
        }

        // DELETE: api/IncidentReports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IncidentReport>> DeleteIncidentReport(int id)
        {
            var incidentReport = await _context.IncidentReport.FindAsync(id);
            if (incidentReport == null)
            {
                return NotFound();
            }

            _context.IncidentReport.Remove(incidentReport);
            await _context.SaveChangesAsync();

            return incidentReport;
        }

        private bool IncidentReportExists(int id)
        {
            return _context.IncidentReport.Any(e => e.Id == id);
        }
    }
}
