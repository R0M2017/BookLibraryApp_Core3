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
            return new PagedList<Library>(_context.Library.Where(l => l.AccountId == accountid), options);
        }

/*        public PagedList<Library> GetBookLibraries(QueryOptions options)
        {

        }*/
        public Library GetLibrary(int libraryid) => _context.Library.First(l => l.LibraryId == libraryid);
        public int GetID() => _context.Library.ToArray().Length;

        public void AddLibrary(Library library)
        {
            _context.Library.Add(library);
            _context.SaveChanges();
        }

        public void RemoveLibrary(Library library)
        {
            _context.Library.Remove(library);
            _context.SaveChanges();
        } 
    }
}
