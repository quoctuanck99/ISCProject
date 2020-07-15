using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISCProject_API.Models;
using ISCProject_Models;

namespace ISCProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowsController : ControllerBase
    {
        private readonly FotozyContext _context;

        public FollowsController(FotozyContext context)
        {
            _context = context;
        }

        // GET: api/Follows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> GetFollow()
        {
            return await _context.Follow.ToListAsync();
        }

        // GET: api/Follows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Follow>> GetFollow(int id)
        {
            var follow = await _context.Follow.FindAsync(id);

            if (follow == null)
            {
                return NotFound();
            }

            return follow;
        }

        // PUT: api/Follows/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFollow(int id, Follow follow)
        {
            if (id != follow.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(follow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FollowExists(id))
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

        // POST: api/Follows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Follow>> PostFollow(Follow follow)
        {
            _context.Follow.Add(follow);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FollowExists(follow.AccountId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFollow", new { id = follow.AccountId }, follow);
        }

        [HttpDelete]
        public async Task<ActionResult<Follow>> DeleteFollow(int AccountId, int FollowingId)
        {
            var follow = await _context.Follow.FindAsync(AccountId, FollowingId);
            if (follow == null)
            {
                return NotFound();
            }

            _context.Follow.Remove(follow);
            await _context.SaveChangesAsync();

            return follow;
        }

        private bool FollowExists(int id)
        {
            return _context.Follow.Any(e => e.AccountId == id);
        }
    }
}
