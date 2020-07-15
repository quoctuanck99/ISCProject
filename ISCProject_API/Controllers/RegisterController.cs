using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISCProject_API.Models;
using ISCProject_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISCProject_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly FotozyContext _context;

        public RegisterController(FotozyContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Register>> PostFollow(Register register)
        {
            Account acc = new Account();
            acc.AccountName = register.Username;
            acc.HashedPassword = register.Password;


            User user = new User();
            user.FullName = register.Fullname;
            user.Phone = register.Phonenumber;
            user.Email = register.Email;
            user.Dob = register.Dob;
            user.Gender = register.Gender;
            user.Username = register.Username;
            user.DateCreated = DateTime.Now;
            user.IsActive = true;
            user.IsAgency = false;

            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Account.Add(acc);
                    _context.SaveChanges();
                    user.AccountId = acc.AccountId;

                    _context.User.Add(user);
                    _context.SaveChanges();
                    trans.Commit();
                    return Ok();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    return Conflict();
                }
            }
        }
    }
}
