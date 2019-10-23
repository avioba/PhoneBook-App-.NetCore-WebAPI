using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly SubscriberContext _context;

        public SubscriberController(SubscriberContext context)
        {
            _context = context;
        }

        // GET: api/Subscriber
        [HttpGet]
        public IEnumerable<Subscriber> GetSubscriber()
        {
            return _context.Subscriber;
        }
        

        // PUT: api/Subscriber/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriber([FromRoute] int id, [FromBody] Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriber.id)
            {
                return BadRequest();
            }

            _context.Entry(subscriber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
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

        // GET: api/Subscriber/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subscriber>> GetSubscriber(int id)
        {
            var subscriber = await _context.Subscriber.FindAsync(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return subscriber;
        }


        // POST: api/Subscriber
        [HttpPost]
        public async Task<IActionResult> PostSubscriber([FromBody] Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Subscriber.Add(subscriber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriber", new { subscriber.id }, subscriber);
        }

        // DELETE: api/Subscriber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subscriber = await _context.Subscriber.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            _context.Subscriber.Remove(subscriber);
            await _context.SaveChangesAsync();

            return Ok(subscriber);
        }

        private bool SubscriberExists(int id)
        {
            return _context.Subscriber.Any(e => e.id == id);
        }
    }
}