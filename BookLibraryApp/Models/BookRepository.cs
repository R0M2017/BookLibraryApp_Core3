using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public class BookRepository : IRepository
    {
        private BookLibraryContext _context;

        public BookRepository(BookLibraryContext context) => _context = context;

        public IEnumerable<Books> Books => _context.Books.ToArray();

        public void AddBook(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}
