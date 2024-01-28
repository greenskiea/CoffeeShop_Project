using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPMUD_Project.DTO
{
    internal class Account
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public Account() { }

        public Account(string email, string username, string password, string type)
        {
            Email = email;
            Username = username;
            Password = password;
            Type = type;
        }

        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
