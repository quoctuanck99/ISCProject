using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISCProject.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using ISCProject_Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ISCProject.Controllers
{
    public class HomeController : ModifiedController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("home/index")]
        public async Task<IActionResult> IndexAsync(string Username, string TagName)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(BaseAPI + "Posts?AccountId=" + HttpContext.Session.GetInt32("AccountId") + "&Username=" + Username + "&TagName=" + TagName);
            string apiResponse = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(apiResponse);

            List<BigPost> post = JsonConvert.DeserializeObject<List<BigPost>>(jObject["post"].ToString());
            List<User> users = JsonConvert.DeserializeObject<List<User>>(jObject["users"].ToString());

            ViewBag.post = post;
            ViewBag.users = users;

            if (Username != null)
                ViewBag.Username = Username;
            if (TagName != null)
                ViewBag.TagName = TagName;

            return View("/Views/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
