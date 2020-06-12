using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BookLibraryApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Crypto.Tls;

namespace BookLibraryApp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepo) => accountRepository = accountRepo;

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Accounts user)
        {
            string formatedPhonenumber;
            int userID = accountRepository.GetID() + 1;
            if (user.Username != null && accountRepository.Accounts.Any(u => u.Username.ToLower() == user.Username.ToLower()))
                ModelState.AddModelError("Username", "Username address already exists");
            if (user.Email != null && accountRepository.Accounts.Any(u => u.Email.ToLower() == user.Email.ToLower()))
                ModelState.AddModelError("Email", "Email address already exists");
            if (user.Phonenumber != null)
            {
                formatedPhonenumber = Regex.Replace(user.Phonenumber, @"[^0-9a-zA-Z]+", "");
                if (accountRepository.Accounts.Any(u => u.Phonenumber == formatedPhonenumber))
                    ModelState.AddModelError("Phonenumber", "Phone Number already exists");
            }
            if (ModelState.IsValid)
            {
                formatedPhonenumber = Regex.Replace(user.Phonenumber, @"[^0-9a-zA-Z]+", "");
                accountRepository.Register(new Accounts
                {
                    AccountId = userID,
                    Username = user.Username,
                    Email = user.Email,
                    Phonenumber = formatedPhonenumber,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Dateofbirth = user.Dateofbirth,
                    Datecreated = DateTime.Now,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    RoleId = 1
                });

                /*Accounts repoUser = accountRepository.Login(user.Username, user.Email, user.Password);
        var userClaims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, repoUser.Firstname),
            new Claim(ClaimTypes.Email, repoUser.Email)
        };
        var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
        var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity });

        HttpContext.SignInAsync(userPrinciple);*/

                return RedirectToAction("RegisterVertification", "Account", new { accountID = userID });
            }
            return View(user);
        }

        public IActionResult RegisterVertification(int accountID)
        {
            if (accountRepository.GetAccount(accountID) != null)
                return View(accountRepository.GetAccount(accountID));
            return View();
        }

        [HttpPost]
        public IActionResult RegisterVertification(Accounts user)
        {
            Accounts repoUser = accountRepository.Accounts.First(u => u.Username == user.Username && u.Email == user.Email && u.Password == user.Password);
            if (repoUser != null)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, repoUser.Username),
                    new Claim(ClaimTypes.Email, repoUser.Email)
                };
                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrinciple);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }


        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(Accounts user)
        {
            if (user.Username == null)
                ModelState.AddModelError("Username", "Username is required");
            if (user.Password == null)
                ModelState.AddModelError("Password", "Password is required");
            if (user.Username != null && !accountRepository.Accounts.Any(u => u.Username.ToLower() == user.Username.ToLower()))
                ModelState.AddModelError("Username", "Username address does not exist");
            if (user.Username != null && user.Password != null)
            {
                if (accountRepository.Accounts.Any(u => u.Username == user.Username && u.Password == user.Password))
                {
                    Accounts repoUser = accountRepository.Accounts.First(u => u.Username == user.Username && u.Password == user.Password);
                    if (repoUser != null)
                    {
                        var userClaims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Name, repoUser.Username),
                            new Claim(ClaimTypes.Email, repoUser.Email)
                        };
                        var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");
                        var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity });
                        HttpContext.SignInAsync(userPrinciple);

                        return RedirectToAction("Index", "Home");
                    }
                    Console.WriteLine("repoUser is null");
                }
                ModelState.AddModelError("Password", "Incorrect Password");
            }
            Console.WriteLine(accountRepository.Accounts.Any(u => u.Username == user.Username && u.Password == user.Password));
            return View(user);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
                HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}