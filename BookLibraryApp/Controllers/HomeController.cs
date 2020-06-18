using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BookLibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;
        public HomeController(IRepository repo) => repository = repo;
        public IActionResult Index()
        {
            Random rand = new Random();
            
            return View(repository.GetTop10Books(rand));
        }
        public IActionResult About() => View();
        public IActionResult Privacy() => View();
        public IActionResult Contact() => View();
        public IActionResult Feedback() => View();
        public IActionResult TermsAndUse() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}