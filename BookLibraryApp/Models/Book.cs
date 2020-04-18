using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }
        public long ISBN { get; set; }
        public int NumberPages { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Language { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
