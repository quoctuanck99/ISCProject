using ISCProject_API.Models;
using System.Linq;
using ISCProject_Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISCProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FotozyContext _context;

        public UserController(FotozyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Profile> GetProfile(int AccountId, int? FollowingId)
        {
            FollowingId = FollowingId == null ? AccountId : FollowingId;
            var profile = (from a in _context.User
                           where a.AccountId.Equals(AccountId)
                           select new Profile
                           {
                               Info = a.Info,
                               NumPost = a.Post.Count(),
                               NumFollowing = a.FollowAccount.Count(),
                               NumFollower = a.FollowFollowing.Count(),
                               Username = a.Username,
                               IsFollowing = a.FollowFollowing.Select(x => x.AccountId).Contains(FollowingId.Value),
                               AccountId = a.AccountId,
                           }).FirstOrDefault();
            return profile;
        }
    }
}