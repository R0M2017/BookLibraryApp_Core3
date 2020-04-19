using System;
using System.Collections.Generic;

namespace BookLibraryApp.booklibrarydatabase
{
    public partial class Bookratings
    {
        public int UserId { get; set; }
        public string Isbn { get; set; }
        public int BookRating { get; set; }
    }
}
