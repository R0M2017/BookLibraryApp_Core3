using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository;
        public AccountController(IAccountRepository repo) => accountRepository = repo;

        public IActionResult Register(Users user)
        {
            accountRepository.Register(user);
            return RedirectToAction(nameof(Users));
        }

        public IActionResult Login(string UserName, string Password)
        {
            return View(accountRepository.Login(UserName, Password));
        }

        [Authorize]
        public ActionResult Users()
        {
            return View();
        }
    }
}