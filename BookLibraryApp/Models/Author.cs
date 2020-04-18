using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Book> Books { get; } = new List<Book>();
    }
}
