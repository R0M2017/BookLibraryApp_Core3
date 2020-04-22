using BookLibraryApp.Models.Pages;
using Microsoft.EntityFrameworkCore;
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

        public PagedList<Books> GetBooks(QueryOptions options)
        {
            return new PagedList<Books>(_context.Books, options);
        }

        public Books GetBook(string isbn) => _context.Books.Find(isbn);

        public void AddBook(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Books book)
        {
            Books b = GetBook(book.Isbn);
            b.BookTitle = book.BookTitle;
            b.BookAuthor = book.BookAuthor;
            b.Publisher = book.Publisher;
            b.YearOfPublication = book.YearOfPublication;
            b.Isbn = book.Isbn;
            //_context.Books.Update(book);
            _context.SaveChanges();
        }

        // public Books GetBooks(string isbn) => _context.Books.Include(b => b.YearOfPublication).First(b => b.Isbn == isbn);
    }
}
