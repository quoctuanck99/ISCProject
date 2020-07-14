using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ISCProject_Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> LoginAsync(string exampleInputEmail1, string exampleInputPassword1)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(BaseAPI + "Accounts");
            string apiResponse = await response.Content.ReadAsStringAsync();
            List<Account> account = JsonConvert.DeserializeObject<List<Account>>(apiResponse);
            return View("/Views/Home/Index.cshtml");
        }
    }
}
