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
            return View("/Views/LoginAndReg/Login.cshtml");
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string exampleInputUsername1, string exampleInputPassword1)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(BaseAPI + "Login?username=" + exampleInputUsername1 + "&password=" + exampleInputPassword1);
            string apiResponse = await response.Content.ReadAsStringAsync();
            Account account = JsonConvert.DeserializeObject<Account>(apiResponse);
            if (account == null)
                return Redirect("/login");
            else
            {
                //HttpContext.Session.Set("UserID", account.AccountId);
                return View("/Views/Home/Index.cshtml");
            }
        }
    }
}
