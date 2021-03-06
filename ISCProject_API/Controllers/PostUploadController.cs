﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ISCProject_API.Models;
using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostUploadController : ControllerBase
    {
        private readonly FotozyContext _context;

        public PostUploadController(FotozyContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpPost]
        public async Task<ActionResult> UploadPost(PostData post_data)
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {

                    List<HashTag> tags = new List<HashTag>();
                    string[] tagslist = post_data.tags.Split(',');
                    List<HashTag> existed_tags = _context.HashTag.Where(x => tagslist.Contains(x.TagName)).ToList();
                    List<int> tagg = existed_tags.Select(x => x.TagId).ToList();
                    ////////////////////////////////////////////
                    foreach (string t in tagslist)
                    {
                        if (!existed_tags.Where(x => x.TagName == t).Any())
                        {
                            tags.Add(new HashTag() { TagName = t });
                        }
                    }
                    foreach (HashTag h in tags)
                    {
                        _context.HashTag.Add(h);
                    }
                    await _context.SaveChangesAsync();
                    tagg = tagg.Union(tags.Select(x => x.TagId)).ToList();
                    /////////////////////////////////////////////////////////
                    Post post = new Post()
                    {
                        AccountId = post_data.AccountId,
                        Description = post_data.Description,
                        NumbFavorite = post_data.NumbFavorite,
                        DateCreated = post_data.DateCreated,
                        Checkin = post_data.Checkin,
                        IsAds = post_data.IsAds
                    };
                    _context.Post.Add(post);
                    await _context.SaveChangesAsync();
                    /////////////////////////////////////////////
                    foreach (int h in tagg)
                    {
                        _context.PostTag.Add(new PostTag()
                        {
                            PostId = post.PostId,
                            TagId = h
                        });
                    }
                    await _context.SaveChangesAsync();
                    /////////////////////////////////////////////////////
                    Image img = new Image()
                    {
                        ImageName = post_data.link,
                        DateUploaded = post_data.DateCreated
                    };
                    _context.Image.Add(img);
                    _context.SaveChanges();
                    _context.PostImage.Add(new PostImage()
                    {
                        PostId = post.PostId,
                        ImageId = img.ImageId
                    });
                    await _context.SaveChangesAsync();
                    ////////////////////////////////////////////////////////
                    await trans.CommitAsync();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                    await trans.RollbackAsync();
                }
            }
            return Ok();
        }

    }
}
