using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryApp.Models;
using BookLibraryApp.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApp.Controllers
{
    public class LibraryController : Controller
    {
        private IRepository repository;
        public LibraryController(IRepository repo) => repository = repo;
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetBooks(options));
        }
    }
}