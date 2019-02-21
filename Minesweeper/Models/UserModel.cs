using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper.Models
{
    public class UserModel
    {
        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        // Read Only Property
        public string Password { get; private set; }

        public UserModel(string _firstName, string _lastName, string _gender, int _age, 
            string _state, string _email, string _username, string _password)
        {
            FirstName = _firstName;
            LastName = _lastName;
            Gender = _gender;
            Age = _age;
            State = _state;
            Email = _email;
            Username = _username;
            Password = _password;
        }
    }
}