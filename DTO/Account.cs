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
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Personal_ID { get; set; }
        public string DOB { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }


        public Account() { }

        public Account(string username, string password, string email, string type, string name,string address,  string phonenumber, string personal_ID, string dob, int gender)
        {
            Username = username;
            Password = password;
            Email = email;
            Type = type;
            Name = name;
            Address = address;
            PhoneNumber = phonenumber;
            Personal_ID = personal_ID;
            DOB = dob;
            Gender = gender;
        }

        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
