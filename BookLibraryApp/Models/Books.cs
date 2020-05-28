using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Books
    {
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public uint? YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public string ImageUrlS { get; set; }
        public string ImageUrlM { get; set; }
        public string ImageUrlL { get; set; }
    }
}
