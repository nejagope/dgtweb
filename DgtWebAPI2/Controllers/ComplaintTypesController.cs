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
    public class ComplaintTypesController : ControllerBase
    {
        private readonly APIDBContext _context;

        public ComplaintTypesController(APIDBContext context)
        {
            _context = context;
        }

        // GET: api/ComplaintTypes
        [HttpGet]
        public IEnumerable<ComplaintType> GetComplaintTypes()
        {
            return _context.ComplaintTypes;
        }

        // GET: api/ComplaintTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComplaintType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var complaintType = await _context.ComplaintTypes.FindAsync(id);

            if (complaintType == null)
            {
                return NotFound();
            }

            return Ok(complaintType);
        }

        // PUT: api/ComplaintTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComplaintType([FromRoute] int id, [FromBody] ComplaintType complaintType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != complaintType.Id)
            {
                return BadRequest();
            }

            _context.Entry(complaintType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComplaintTypeExists(id))
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

        // POST: api/ComplaintTypes
        [HttpPost]
        public async Task<IActionResult> PostComplaintType([FromBody] ComplaintType complaintType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ComplaintTypes.Add(complaintType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComplaintType", new { id = complaintType.Id }, complaintType);
        }

        // DELETE: api/ComplaintTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaintType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var complaintType = await _context.ComplaintTypes.FindAsync(id);
            if (complaintType == null)
            {
                return NotFound();
            }

            _context.ComplaintTypes.Remove(complaintType);
            await _context.SaveChangesAsync();

            return Ok(complaintType);
        }

        private bool ComplaintTypeExists(int id)
        {
            return _context.ComplaintTypes.Any(e => e.Id == id);
        }
    }
}