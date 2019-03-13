using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace Minesweeper.Models
{
    public class UserModel
    {
        // Properties
        [Required]
        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Age must be Numeric")]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "State")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Must be valid email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        // Read Only Property
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public UserModel()
        {
            // Do nothing.
        }

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