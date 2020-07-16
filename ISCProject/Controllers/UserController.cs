using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            using var response = await httpClient.GetAsync(BaseAPI + "Profile?AccountId=" + AccountId + "&FollowingId=" + (AccountId == HttpContext.Session.GetInt32("AccountId") ? AccountId : HttpContext.Session.GetInt32("AccountId")));
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(apiResponse);
                Profile profile = JsonConvert.DeserializeObject<Profile>(jObject["profile"].ToString());
                List<Image> images = JsonConvert.DeserializeObject<List<Image>>(jObject["images"].ToString());
                ViewBag.profile = profile;
                ViewBag.images = images;
            }
            ViewBag.current = AccountId == HttpContext.Session.GetInt32("AccountId");
            ViewBag.BaseAPI = BaseAPI;
            return View("Views/Home/UserPage.cshtml");
        }

        [Route("user/edit-info")]
        public IActionResult Edit()
        {
            return View("Views/Home/EditInformation.cshtml");
        }


        [Route("user/upload-photo")]
        [HttpPost]
        public async Task<IActionResult> Upload(string json)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");
            PostData data = JsonConvert.DeserializeObject<PostData>(json);
            data.AccountId = (int)HttpContext.Session.GetInt32("AccountId");
            data.IsAds = (int)HttpContext.Session.GetInt32("IsAgency") == 1;
            data.DateCreated = DateTime.Now;
            using var httpClient = new HttpClient();
            using var response1 = await httpClient.PostAsync(BaseAPI + "PostUpload", new StringContent(JsonConvert.SerializeObject(data), UnicodeEncoding.UTF8, "application/json"));
            string apiResponse = await response1.Content.ReadAsStringAsync();
            if (response1.IsSuccessStatusCode)
            {
                return Json(new { message = "Upload success!" });
            }
            else
            {
                return Json(new { message = "Upload failed!" });
            }

        }

        [Route("user/add-following")]
        [HttpPost]
        public async Task<IActionResult> AddFollow(int AccountId)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            using var httpClient = new HttpClient();
            Follow follow = new Follow
            {
                AccountId = HttpContext.Session.GetInt32("AccountId").Value,
                FollowingId = AccountId
            };
            var json = JsonConvert.SerializeObject(follow);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using var response = await httpClient.PostAsync(BaseAPI + "Follows", stringContent);
            return Redirect("/user/personalPage?AccountId=" + AccountId);
        }

        [Route("user/delete-following")]
        public async Task<IActionResult> DeleteFollow(int AccountId)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            using var httpClient = new HttpClient();
            using var response = await httpClient.DeleteAsync(BaseAPI + "Follows?AccountId=" + HttpContext.Session.GetInt32("AccountId") + "&FollowingId=" + AccountId);
            return Redirect("/user/personalPage?AccountId=" + AccountId);
        }
    }
}
