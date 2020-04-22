using BookLibraryApp.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public interface IRepository 
    {
        IEnumerable<Books> Books { get; }
        PagedList<Books> GetBooks(QueryOptions options);

        //Books GetBooks(string isbn);
        void AddBook(Books book);
        //void UpdateBook(Books book);
    }
}
