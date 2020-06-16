using BookLibraryApp.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public interface ILibraryRepository
    {
        IEnumerable<Library> Library { get; }
        PagedList<Library> GetLibraries(QueryOptions options, int accountid);
        Library GetLibrary(int libraryid);
        int GetID();
        bool BookLibraryExists(int bookID, int accountID);
        void AddLibrary(Library library);
        void RemoveLibrary(int bookID, int accountID);
    }
}
