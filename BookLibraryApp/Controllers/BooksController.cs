using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Models;
using BookLibraryApp.Models.Pages;

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

        public IActionResult UpdateBook(string isbn)
        {
            return View(repository.GetBook(isbn));
        }

        [HttpPost]
        public IActionResult UpdateBook(Books book)
        {
            repository.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }
    }
}
