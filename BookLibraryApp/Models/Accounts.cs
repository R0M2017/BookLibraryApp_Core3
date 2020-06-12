using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryApp.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Library = new HashSet<Library>();
        }

        public int AccountId { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime Dateofbirth { get; set; }
        public DateTime Datecreated { get; set; }
        [Required]
        //[StringLength(8, ErrorMessage = "Password must be 8 characters long")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "Confirm Password must match Password")]
        public string ConfirmPassword { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Library> Library { get; set; }

        /*public IEnumerable<Accounts> GetUsers()
        {
            return new List<Accounts>()
            {
                new Accounts
                {
                    AccountId = 1,
                    Username = "johndoe420",
                    Email = "jonnyd120@gmail.com",
                    Phonenumber = "4051238967",
                    Firstname = "John",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "johndoe42069",
                    RoleId = 1
                }
            };
        }*/
    }
}
