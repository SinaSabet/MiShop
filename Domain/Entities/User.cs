using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Domain.Enums;
using UserProfileService.Domain.SeedWork;
using UserProfileService.Domain.ValueObjects;

namespace UserProfileService.Domain.Entities
{
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public Gender Gender { get; set; }


        public User()
        {
            
        }

        public User(string firstName, string lastName, string email, string userName, string password, Address address, Gender gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            Password = password;
            Address = address;
            Gender = gender;
        }

    }
}
