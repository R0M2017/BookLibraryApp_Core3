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

        /*void AddBook(Books book);*/
    }
}
