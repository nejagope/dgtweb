using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DgtWebAPI2;
using DgtWebApi2.Models;

namespace DgtWebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly APIDBContext _context;

        public ComplaintsController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/Complaints
        [HttpGet]
        public IEnumerable<Complaint> GetComplaints()
        {
            return _context.Complaints;
        }

        // GET: api/Complaints/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplaint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var complaint = await _context.Complaints.FindAsync(id);

            if (complaint == null)
            {
                return NotFound();
            }

            return Ok(complaint);
        }

        // PUT: api/Complaints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaint([FromRoute] int id, [FromBody] Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complaint.Id)
            {
                return BadRequest();
            }

            _context.Entry(complaint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintExists(id))
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

        // POST: api/Complaints
        [HttpPost]
        public async Task<IActionResult> PostComplaint([FromBody] Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplaint", new { id = complaint.Id }, complaint);
        }

        // DELETE: api/Complaints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }

            _context.Complaints.Remove(complaint);
            await _context.SaveChangesAsync();

            return Ok(complaint);
        }

        private bool ComplaintExists(int id)
        {
            return _context.Complaints.Any(e => e.Id == id);
        }
    }
}