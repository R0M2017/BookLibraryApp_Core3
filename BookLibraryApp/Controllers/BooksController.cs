using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Models;
using BookLibraryApp.Models.Pages;
using Nancy.Json;
using BookLibraryApp.Models.data;

namespace BookLibraryApp.Controllers
{
    public class BooksController : Controller
    {

        private IRepository repository;
        public BooksController(IRepository repo) => repository = repo;

        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetBooks(options));
        }

        [HttpPost]
        public IActionResult AddBook(Books book)
        {
            repository.AddBook(book);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateBook(int bookid)
        {
            return View(repository.GetBook(bookid));
        }

        [HttpPost]
        public IActionResult UpdateBook(Books book)
        {
            repository.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateAll()
        {
            ViewBag.UpdateAll = true;
            return View(nameof(Index), repository.Books);
        }

        [HttpPost]
        public IActionResult UpdateAll(Books[] books)
        {
            repository.UpdateAll(books);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Books book)
        {
            repository.Delete(book);
            return RedirectToAction(nameof(Index));
        }

        public isbnStorage[] isbnStorage;

        public JsonResult InsertISBN(string isbn)
        {
            var js = new JavaScriptSerializer();
            isbnStorage = js.Deserialize<isbnStorage[]>(isbn);
            //foreach (var i in isbnStorage)
                //System.Diagnostics.Debug.WriteLine("\n\n" + i + "\n\n");
                // System.Diagnostics.Debug.WriteLine("\n\n" + isbn + "\n\n");
                return Json("result");
        }
    }
}
