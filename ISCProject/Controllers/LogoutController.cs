using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ISCProject.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("AccountId") != null)
            {
                HttpContext.Session.Remove("AccountId");
                HttpContext.Session.Remove("Email");
            }
            return Redirect("/login");
        }
    }
}