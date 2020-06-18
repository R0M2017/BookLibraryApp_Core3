using BookLibraryApp.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public class LibraryRepository : ILibraryRepository
    {
        private BookLibraryContext _context;
        public LibraryRepository(BookLibraryContext context) => _context = context;
        public IEnumerable<Library> Library => _context.Library.ToArray();
        public PagedList<Library> GetLibraries(QueryOptions options, int accountid)
        {
            return new PagedList<Library>(_context, _context.Library.Where(l => l.AccountId == accountid), options);
        }

/*        public PagedList<Library> GetBookLibraries(QueryOptions options)
        {

        }*/
        public Library GetLibrary(int libraryid) => _context.Library.First(l => l.LibraryId == libraryid);
        public int GetID() => _context.Library.ToArray().Length;

        public bool BookLibraryExists(int bookID, int accountID)
        {
            if (_context.Library.Any(l => l.BookId == bookID && l.AccountId == accountID))
                return true;
            return false;
        }


        public void AddLibrary(Library library)
        {
            _context.Library.Add(library);
            _context.SaveChanges();
        }

        public void RemoveLibrary(int bookID, int accountID)
        {
            Library library = _context.Library.First(l => l.BookId == bookID && l.AccountId == accountID);
            _context.Library.Remove(library);
            _context.SaveChanges();
        } 
    }
}
