﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISCProject_API.Models;
using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ProfilePictureController : ControllerBase
    {

        private readonly FotozyContext _context;

        public ProfilePictureController(FotozyContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult ChangePicture(string uploadProfilePicture)
        {
            string a = Request.Form["uploadProfilePicture"];
            string un = a.Split('|')[0];
            User user = _context.User.Where(w => w.Username.Equals(un)).SingleOrDefault();
            user.Avatar = a.Split('|')[1];
            _context.SaveChanges();
            //FollowingId = FollowingId == null ? AccountId : FollowingId;
            //var profile = (from a in _context.User
            //               where a.AccountId.Equals(AccountId)
            //               select new Profile
            //               {
            //                   Info = a.Info,
            //                   NumPost = a.Post.Count(),
            //                   NumFollowing = a.FollowAccount.Count(),
            //                   NumFollower = a.FollowFollowing.Count(),
            //                   Username = a.Username,
            //                   IsFollowing = a.FollowFollowing.Select(x => x.AccountId).Contains(FollowingId.Value),
            //                   AccountId = a.AccountId,
            //               }).FirstOrDefault();

            //var images = _context.PostImage.Where(x => x.Post.AccountId == AccountId).Select(x => x.Image).ToList();

            return Ok();
        }
    }
}
