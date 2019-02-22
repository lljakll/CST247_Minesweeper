using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Minesweeper.Models
{
    public class UserModel
    {
        // Properties
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
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