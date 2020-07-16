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
    public class PostsController : ControllerBase
    {
        private readonly FotozyContext _context;

        public PostsController(FotozyContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BigPost>>> GetListPost(int AccountId)
        {
            var Ids = await _context.Follow.Where(x => x.AccountId == AccountId).Select(x => x.FollowingId).ToListAsync();
            Ids.Add(AccountId);

            var Post = await _context.Post.Where(x => Ids.Contains(x.AccountId)).Select(x => new BigPost
            {
                PostId = x.PostId,
                Avatar = x.Account.Avatar,
                Username = x.Account.Username,
                Checkin = x.Checkin,
                Description = x.Description,
                Images = x.PostImage.Select(x => x.Image).ToList(),
                IsFavorite = x.FavoritePost.Where(x => x.AccountId == AccountId).Any(),
                NumFavorite = x.FavoritePost.Count(),
                Comments = x.Comment.ToList(),
                DateCreated = x.DateCreated,
                AccountId = x.AccountId,
                hashTags = x.PostTag.Select(x => x.Tag).ToList()
            }).OrderByDescending(x => x.DateCreated).ToListAsync();

            //if (!Post.Any())
            //{
            //    Post = await _context.Post.Select(x => new BigPost
            //    {
            //        PostId = x.PostId,
            //        Avatar = x.Account.Avatar,
            //        Username = x.Account.Username,
            //        Checkin = x.Checkin,
            //        Description = x.Description,
            //        Images = x.PostImage.Select(x => x.Image).ToList(),
            //        Comments = x.Comment.ToList(),
            //        DateCreated = x.DateCreated,
            //        AccountId = x.AccountId,
            //        hashTags = x.PostTag.Select(x => x.Tag).ToList()
            //    }).OrderByDescending(x => x.DateCreated).ToListAsync();
            //}

            IEnumerable<Comment> Comments = new List<Comment>();
            foreach (var item in Post)
            {
                Comments = Comments.Union(item.Comments);
            }

            List<int> AccountCommentId = Comments.Select(x => x.AccountId).Distinct().ToList();

            var Users = await _context.User.Where(x => AccountCommentId.Contains(x.AccountId)).Select(x => new
            {
                x.AccountId,
                x.Username
            }).ToListAsync();
            return Ok(new { Post, Users });
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Post.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.PostId == id);
        }
    }
}
