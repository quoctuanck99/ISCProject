using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ISCProject_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ISCProject.Controllers
{
    public class LoginController : Controller
    {
        public readonly string BaseAPI = Environment.GetEnvironmentVariable("BaseAPI");

        [Route("login")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("AccountId") == null)
                return View("/Views/LoginAndReg/Login.cshtml");
            else
                return Redirect("/home/index");
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string exampleInputUsername1, string exampleInputPassword1)
        {
            using var httpClient = new HttpClient();
            using var response1 = await httpClient.GetAsync(BaseAPI + "Login?username=" + exampleInputUsername1 + "&password=" + exampleInputPassword1);
            string apiResponse = await response1.Content.ReadAsStringAsync();
            Account account = JsonConvert.DeserializeObject<Account>(apiResponse);

            if (account == null)
                return Redirect("/login");
            else
            {
                HttpContext.Session.SetInt32("AccountId", account.AccountId);
                using var response2 = await httpClient.GetAsync(BaseAPI + "Users/" + account.AccountId);
                if (response2.IsSuccessStatusCode)
                {
                    apiResponse = await response2.Content.ReadAsStringAsync();
                    User user = JsonConvert.DeserializeObject<User>(apiResponse);
                    HttpContext.Session.SetString("Email", user.Email);
                }
                return Redirect("/home/index");
            }
        }
    }
}
