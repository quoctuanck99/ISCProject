using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ISCProject.Controllers
{
    public class UserController : ModifiedController
    {
        [Route("user/personalPage")]
        public async Task<IActionResult> IndexAsync(int? AccountId)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            AccountId = AccountId == null ? HttpContext.Session.GetInt32("AccountId").Value : AccountId;
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(BaseAPI + "User?AccountId=" + AccountId + "&FollowingId=" + (AccountId == HttpContext.Session.GetInt32("AccountId") ? AccountId : HttpContext.Session.GetInt32("AccountId")));
            string apiResponse = await response.Content.ReadAsStringAsync();
            Profile profile = JsonConvert.DeserializeObject<Profile>(apiResponse);
            ViewBag.profile = profile;
            ViewBag.current = AccountId == HttpContext.Session.GetInt32("AccountId");
            return View("Views/Home/UserPage.cshtml");
        }

        [Route("user/edit-info")]
        public IActionResult Edit()
        {
            return View("Views/Home/EditInformation.cshtml");
        }

        
        [Route("user/upload-photo")]
        [HttpPost]
        public ActionResult Upload(string json)
        {
            PostData data= JsonConvert.DeserializeObject<PostData>(json);
            return null;
        }
        class PostData
        {
            public string link { get; set; }
            public string description { get; set; }
            public string tags { get; set; }
            public string location { get; set; }
        }
    }
}
