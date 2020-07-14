using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject.Controllers
{
    public class RegisterController : Controller
    {
        [Route("register")]
        public IActionResult Index()
        {
            return View("Views/LoginAndReg/Register.cshtml");
        }
    }
}
