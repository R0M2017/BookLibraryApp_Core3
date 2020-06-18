using BookLibraryApp.Models.api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookLibraryApp.Models.Pages
{
    public class PagedList<T> : List<T>
    {
        public PagedList(BookLibraryContext context, IQueryable<T> query, QueryOptions options = null)
        {
            _context = context;
            CurrentPage = options.CurrentPage;
            PageSize = options.PageSize;
            Options = options;

            if (options != null)
            {
                //Console.WriteLine(options.SearchIsbnTerm);
                //IsbnDbApi(options.SearchIsbnTerm);
                if (!string.IsNullOrEmpty(options.OrderPropertyName))
                    query = Order(query, options.OrderPropertyName, options.DescendingOrder);
                if (!string.IsNullOrEmpty(options.SearchPropertyName) && !string.IsNullOrEmpty(options.SearchTerm))
                    query = Search(query, options.SearchPropertyName, options.SearchTerm);
                if (!string.IsNullOrEmpty(options.SearchIsbnName) && !string.IsNullOrEmpty(options.SearchIsbnTerm))
                    query = SearchISBN(query, options.SearchIsbnName, options.SearchIsbnTerm);
            }

            TotalPages = query.Count() / PageSize;
            AddRange(query.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
        }

        private static BookLibraryContext _context;

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public QueryOptions Options { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        private static IQueryable<T> SearchISBN(IQueryable<T> query, string propertyName, string searchisbnTerm)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var source = propertyName.Split('.').Aggregate((Expression)parameter,
            Expression.Property);
            var body = Expression.Call(source, "Contains", Type.EmptyTypes,
            Expression.Constant(searchisbnTerm, typeof(string)));
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            if (!query.Any(lambda))
            {
                int bookID = _context.Books.ToArray().Length + 1;
                if (_context.Books.Any(b => b.BookId == bookID))
                    bookID += 1;
                book bookModel = IsbnDbApi(searchisbnTerm);
                bookDetails bookInfo = bookModel.Book;
                _context.Books.Add(new Books 
                {
                    BookId = bookID,
                    Isbn = bookInfo.isbn13,
                    BookTitle = bookInfo.title,
                    BookAuthor = bookInfo.authors[0],
                    YearOfPublication = Convert.ToUInt32(bookInfo.date_published),
                    Publisher = bookInfo.publisher,
                    ImageUrlS = bookInfo.image,
                    ImageUrlM = bookInfo.image,
                    ImageUrlL = bookInfo.image,
                });
                _context.SaveChanges();
                return query.Where(lambda);
            }
            return query.Where(lambda);
        }

        public static book IsbnDbApi(string isbn)
        {
            // const string WEBSERVICE_URL = "https://api2.isbndb.com/book/9781934759486";
            string WEBSERVICE_URL = "https://api2.isbndb.com/book/" + isbn;
            book bookModel = new book();
            try
            {
                var webRequest = WebRequest.Create(WEBSERVICE_URL);
                
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.ContentType = "application/json; charset=utf-8";
                    webRequest.Headers["Authorization"] = "44174_37ec3ba969f1f505eb0f2d6ae51b079a";
                    //webRequest.Headers.Add("/book/{isbn}");

                    WebResponse wr = webRequest.GetResponseAsync().Result;
                    Stream receiveStream = wr.GetResponseStream();
                    StreamReader reader = new StreamReader(receiveStream);

                    string content = reader.ReadToEnd();
                    
                    //Console.WriteLine(content);

                    JsonSerializerOptions options = new JsonSerializerOptions();
                    // List<book> bookList = JsonSerializer.Deserialize<List<book>>(content, options);
                    bookModel = JsonSerializer.Deserialize<book>(content, options);
                    // string bookJson = JsonSerializer.Serialize(bookModel, options);
                    // Console.WriteLine(bookJson);
                    return bookModel;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return bookModel;
        }

        private static IQueryable<T> Search(IQueryable<T> query, string propertyName, string searchTerm)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var source = propertyName.Split('.').Aggregate((Expression)parameter,
            Expression.Property);
            var body = Expression.Call(source, "Contains", Type.EmptyTypes,
            Expression.Constant(searchTerm, typeof(string)));
            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            return query.Where(lambda);
        }
        private static IQueryable<T> Order(IQueryable<T> query, string propertyName, bool desc)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var source = propertyName.Split('.').Aggregate((Expression)parameter,
            Expression.Property);
            var lambda = Expression.Lambda(typeof(Func<,>).MakeGenericType(typeof(T),
            source.Type), source, parameter);
            return typeof(Queryable).GetMethods().Single(
            method => method.Name == (desc ? "OrderByDescending"
            : "OrderBy")
            && method.IsGenericMethodDefinition
            && method.GetGenericArguments().Length == 2
            && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), source.Type)
            .Invoke(null, new object[] { query, lambda }) as IQueryable<T>;
        }
    }
}
