using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISCProject_API.Models;
using ISCProject_Models;

namespace ISCProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly FotozyContext _context;

        public LoginController(FotozyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Account>> CheckLogin(string username, string password)
        {
            return await _context.Account.Where(x => x.AccountName == username && x.HashedPassword == password).FirstOrDefaultAsync();
        }
    }
}
