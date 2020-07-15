using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISCProject.Controllers
{
    [Route("[controller]")]
    public class CommentsController : ModifiedController
    {
        [HttpPost]
        public async Task<IActionResult> Index(int PostId, string Content)
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return Redirect("/login");

            Comment comment = new Comment
            {
                AccountId = HttpContext.Session.GetInt32("AccountId").Value,
                Content = Content,
                DateCreated = DateTime.Now,
                PostId = PostId
            };

            var json = JsonConvert.SerializeObject(comment);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(BaseAPI + "Comments", stringContent);


            return Redirect("/home/index");
        }
    }
}