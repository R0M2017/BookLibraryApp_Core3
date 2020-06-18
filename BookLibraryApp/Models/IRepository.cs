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
        //PagedList<Books> GetLibraryBooks(QueryOptions options, int bookid);
        List<Books> GetTop10Books(Random rand);
        int GetID();
        Books GetBook(int bookid);
        void AddBook(Books book);
        void UpdateBook(Books book);
        void UpdateAll(Books[] books);
        void Delete(Books book);
    }
}
