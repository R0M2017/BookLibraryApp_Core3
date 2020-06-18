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
        private IAccountRepository accountRepository;
        private ILibraryRepository libraryRepository;
        private IRepository bookRepository;
        public LibraryController(IAccountRepository accountRepo, ILibraryRepository libraryRepo, IRepository bookRepo)
        {
            accountRepository = accountRepo;
            libraryRepository = libraryRepo;
            bookRepository = bookRepo;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated && accountRepository.Accounts.Any(u => u.Username == User.Identity.Name))
            {
                Accounts authenticatedAccount = accountRepository.Accounts.First(u => u.Username == User.Identity.Name);
                //return View(libraryRepository.GetLibraries(options, authenticatedAccount.AccountId));
                List<Books> books = new List<Books>();
                IEnumerable<Library> library = libraryRepository.Library.Where(l => l.AccountId == authenticatedAccount.AccountId);
                foreach (Library l in library)
                    books.Add(bookRepository.GetBook(l.BookId));
                    return View(books);
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddToLibrary(int bookid)
        {
            if (User.Identity.IsAuthenticated && accountRepository.Accounts.Any(u => u.Username == User.Identity.Name))
            {
                Accounts authenticatedAccount = accountRepository.Accounts.First(u => u.Username == User.Identity.Name);
                if (libraryRepository.BookLibraryExists(bookid, authenticatedAccount.AccountId))
                {
                    return RedirectToAction(TempData["ViewState"].ToString(), TempData["ControllerState"].ToString());
                }
                int libraryid = libraryRepository.GetID() + 1;
                if (libraryRepository.Library.Any(l => l.LibraryId == libraryid))
                    libraryid += 1;
                libraryRepository.AddLibrary(new Library
                {
                    /*LibraryId = libraryid,*/
                    AccountId = authenticatedAccount.AccountId,
                    BookId = bookid,
                    Datecreated = DateTime.Now
                });
                return RedirectToAction("Index", "Library");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RemoveFromLibrary(int bookid)
        {
            if (User.Identity.IsAuthenticated && accountRepository.Accounts.Any(u => u.Username == User.Identity.Name))
            {
                Accounts authenticatedAccount = accountRepository.Accounts.First(u => u.Username == User.Identity.Name);
                libraryRepository.RemoveLibrary(bookid, authenticatedAccount.AccountId);
            }
            return RedirectToAction("Index", "Library");
        }
    }
}