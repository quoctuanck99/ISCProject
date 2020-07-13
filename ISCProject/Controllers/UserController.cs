using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject.Controllers
{
    public class UserController : Controller
    {
        [Route("user/personalPage")]
        public IActionResult Index()
        {
            return View("Views/Home/UserPage.cshtml");
        }
    }
}
