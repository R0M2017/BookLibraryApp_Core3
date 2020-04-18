using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLibraryApp.Models;

namespace BookLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        LibraryContext context = new LibraryContext();
        public IActionResult Index()
        {
            // DbInitializer.Initialize(context);
            return View();
        }
    }
}