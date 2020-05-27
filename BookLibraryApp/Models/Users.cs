using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Location { get; set; }
        public int? Age { get; set; }
    }
}
