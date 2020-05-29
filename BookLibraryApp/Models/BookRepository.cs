using BookLibraryApp.Models.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
            /*IQueryable<Books> query = _context.Books.Include(b => b.Publisher);
            if (publisher != -0)
            {
                // query = query.Where(b => b.Publisher == publisher);
            }*/
            return new PagedList<Books>(_context.Books, options);
        }

        public Books GetBook(int bookid) => _context.Books.First(b => b.BookId == bookid);

        public void AddBook(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Books book)
        {
            Books b = _context.Books.Find(book.BookId);
            //Books b = GetBook(book.BookId);
            b.Isbn = book.Isbn;
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
            Dictionary<int, Books> data = books.ToDictionary(b => b.BookId);
            IEnumerable<Books> baseline = _context.Books.Where(b => data.Keys.Contains(b.BookId));

            foreach(Books databaseBook in baseline)
            {
                Books requestBook = data[databaseBook.BookId];
                databaseBook.Isbn = requestBook.Isbn;
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
