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
            //_context.Books.Update(book);
            _context.SaveChanges();
        }

        public void UpdateAll(Books[] books)
        {
            //_context.Books.UpdateRange(books);
            Dictionary<string, Books> data = books.ToDictionary(b => b.Isbn);
            IEnumerable<Books> baseline = _context.Books.Where(b => data.Keys.Contains(b.Isbn));

            foreach(Books databaseBook in baseline)
            {
                Books requestBook = data[databaseBook.Isbn];
                databaseBook.BookTitle = requestBook.BookTitle;
                databaseBook.BookAuthor = requestBook.BookAuthor;
                databaseBook.Publisher = requestBook.Publisher;
                databaseBook.YearOfPublication = requestBook.YearOfPublication;
            }
            _context.SaveChanges();
        }

        public void Delete(Books book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
