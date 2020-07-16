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
    public class FavoritePostsController : ControllerBase
    {
        private readonly FotozyContext _context;

        public FavoritePostsController(FotozyContext context)
        {
            _context = context;
        }

        // GET: api/FavoritePosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoritePost>>> GetFavoritePost()
        {
            return await _context.FavoritePost.ToListAsync();
        }

        // GET: api/FavoritePosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoritePost>> GetFavoritePost(int id)
        {
            var favoritePost = await _context.FavoritePost.FindAsync(id);

            if (favoritePost == null)
            {
                return NotFound();
            }

            return favoritePost;
        }

        // PUT: api/FavoritePosts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoritePost(int id, FavoritePost favoritePost)
        {
            if (id != favoritePost.PostId)
            {
                return BadRequest();
            }

            _context.Entry(favoritePost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritePostExists(id))
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

        // POST: api/FavoritePosts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FavoritePost>> PostFavoritePost(FavoritePost favoritePost)
        {
            _context.FavoritePost.Add(favoritePost);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoritePostExists(favoritePost.PostId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavoritePost", new { id = favoritePost.PostId }, favoritePost);
        }

        // DELETE: api/FavoritePosts/5
        [HttpDelete()]
        public async Task<ActionResult<FavoritePost>> DeleteFavoritePost(int PostId, int AccountId)
        {
            var favoritePost = await _context.FavoritePost.FindAsync(PostId, AccountId);
            if (favoritePost == null)
            {
                return NotFound();
            }

            _context.FavoritePost.Remove(favoritePost);
            await _context.SaveChangesAsync();

            return favoritePost;
        }

        private bool FavoritePostExists(int id)
        {
            return _context.FavoritePost.Any(e => e.PostId == id);
        }
    }
}
