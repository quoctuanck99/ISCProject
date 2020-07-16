using System;
using System.Collections.Generic;
using System.Text;

namespace ISCProject_Models
{
    public class Register
    {
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public Boolean Gender { get; set; }
        public DateTime Dob { get; set; }
        public Register() { }
        public Register(string username, string password, string email, string fullname, string phone, Boolean gender, DateTime dob)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Fullname = fullname;
            this.Phonenumber = phone;
            this.Gender = gender;
            this.Dob = dob;
        }
    }
}
