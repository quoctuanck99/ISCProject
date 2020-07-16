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
            Account acc = new Account
            {
                AccountName = register.Username,
                HashedPassword = register.Password,
                Salt = ""
            };
            using var trans = _context.Database.BeginTransaction();
            try
            {
                _context.Account.Add(acc);
                await _context.SaveChangesAsync();

                User user = new User
                {
                    FullName = register.Fullname,
                    Phone = register.Phonenumber,
                    Email = register.Email,
                    Dob = register.Dob,
                    Gender = register.Gender,
                    Username = register.Username,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    IsAgency = false
                };

                user.AccountId = acc.AccountId;

                _context.User.Add(user);
                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return Ok();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                await trans.RollbackAsync();
                return Conflict();
            }
        }
    }
}
