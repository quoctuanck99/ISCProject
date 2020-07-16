using ISCProject_Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISCProject.Controllers
{
    public class RegisterController : ModifiedController
    {


        [Route("register")]
        public IActionResult Index()
        {
            return View("Views/LoginAndReg/Register.cshtml");
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> PostRegister(string username, string password, string email, string fullname, string phone, string gender, DateTime dob)
        {
            using var httpClient = new HttpClient();

            Register register = new Register(username, password, email, fullname, phone, Convert.ToBoolean(gender), dob);
            var json = JsonConvert.SerializeObject(register);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(BaseAPI + "Register", stringContent);
            return Ok();
        }
    }
}
