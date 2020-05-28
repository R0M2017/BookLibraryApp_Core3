using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Library
    {
        public int LibraryId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime Datecreated { get; set; }
    }
}
