using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Accounts
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dateofbirth { get; set; }
        public DateTime Datecreated { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
}
