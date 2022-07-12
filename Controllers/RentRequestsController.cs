using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookBuffetWeb2.DomainClasses;
using BookBuffetWeb2.Data;

namespace BookBuffetWeb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentRequestsController : ControllerBase
    {
        private readonly BackendDBContext _context;

        public RentRequestsController(BackendDBContext context)
        {
            _context = context;
        }

        // GET: api/RentRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentRequest>>> GetRentRequests()
        {
            return await _context.RentRequests.ToListAsync();
        }

        // GET: api/RentRequests/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RentRequest>> GetRentRequest(int id)
        {
            var rentRequest = await _context.RentRequests.FindAsync(id);

            if (rentRequest == null)
            {
                return NotFound();
            }

            return rentRequest;
        }

        // GET: api/RentRequests/{userid}/pending OR api/RentRequests/5/{userid}/done
        [HttpGet("Requester/Get")]
        public async Task<ActionResult<IEnumerable<RentRequest>>> GetRentRequestsByRequesterId(string userid, [FromQuery] string status)
        {
            if(status == "Pending")
            {
                return await _context.RentRequests.Where(e => e.Status == "Pending" && e.RequesterId == userid).ToListAsync();

            }
            else if(status == "Done")
            {
                return await _context.RentRequests.Where(e => e.Status == "Done" && e.RequesterId == userid).ToListAsync();

            }
            else
            {
                return NotFound();
            }       

            
        }

        // GET: api/RentRequests/{userid}/pending OR api/RentRequests/5/{userid}/done
        [HttpGet("Receiver")]
        public async Task<ActionResult<IEnumerable<RentRequest>>> GetRentRequestsByReceiverId(string userid, [FromQuery] string status)
        {
            if (status == "Pending")
            {
                return await _context.RentRequests.Where(e => e.Status == "Pending" && e.ReceiverId == userid).ToListAsync();

            }
            else if (status == "Done")
            {
                return await _context.RentRequests.Where(e => e.Status == "Done" && e.ReceiverId == userid).ToListAsync();

            }
            else
            {
                return NotFound();
            }


        }


        // PUT: api/RentRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentRequest(int id, RentRequest rentRequest)
        {
            if (id != rentRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentRequestExists(id))
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

        // POST: api/RentRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RentRequest>> PostRentRequest(RentRequest rentRequest)
        {
            _context.RentRequests.Add(rentRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRentRequest", new { id = rentRequest.Id }, rentRequest);
        }

        // DELETE: api/RentRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentRequest(int id)
        {
            var rentRequest = await _context.RentRequests.FindAsync(id);
            if (rentRequest == null)
            {
                return NotFound();
            }

            _context.RentRequests.Remove(rentRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentRequestExists(int id)
        {
            return _context.RentRequests.Any(e => e.Id == id);
        }
    }
}
