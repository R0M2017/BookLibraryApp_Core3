using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Users
    {
        public Users()
        {
            Library = new HashSet<Library>();
            Userclaims = new HashSet<Userclaims>();
            Userlogins = new HashSet<Userlogins>();
            Userroles = new HashSet<Userroles>();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Library> Library { get; set; }
        public virtual ICollection<Userclaims> Userclaims { get; set; }
        public virtual ICollection<Userlogins> Userlogins { get; set; }
        public virtual ICollection<Userroles> Userroles { get; set; }
    }
}
