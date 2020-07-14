using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject.Controllers
{
    public class ModifiedController : Controller
    {
        public readonly string BaseAPI = Environment.GetEnvironmentVariable("BaseAPI");
    }
}