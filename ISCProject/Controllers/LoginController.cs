using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISCProject_Models;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject.Controllers
{
    public class LoginController : Controller
    {
        [Route("login")]
        public IActionResult Index()
        {
            return View("Views/LoginAndReg/Login.cshtml");
        }
    }
}
