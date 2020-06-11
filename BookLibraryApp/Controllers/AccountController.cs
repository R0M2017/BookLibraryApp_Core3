using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookLibraryApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Org.BouncyCastle.Crypto.Tls;

namespace BookLibraryApp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepo) => accountRepository = accountRepo;



        /*[HttpPost]
        public IActionResult Register(Users user)
        {
            accountRepository.Register(user);
            return RedirectToAction(nameof(Users));
        }

        public IActionResult Login(string UserName, string Password)
        {
            return View(accountRepository.Login(UserName, Password));
        }*/

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(Accounts user)
        {
            //repository.AddBook(book);
            //return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
            {
                char[] charsToTrim = { '*', ' ', '\'', '(', ')', '-' };
                accountRepository.Register(new Accounts
                {
                    AccountId = accountRepository.GetID() + 1,
                    Username = user.Username,
                    Email = user.Email,
                    Phonenumber = user.Phonenumber.Trim(charsToTrim),
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

                return RedirectToAction("Index", "Home");
            } else 
                return View(user);
        }




        /*public IActionResult Login() => View();

[HttpPost]
public IActionResult Login([Bind] Accounts user)
{
Accounts users = new Accounts();
Accounts allUsers = users.GetUsers().FirstOrDefault();
if (users.GetUsers().Any(u => u.Username == user.Username))
{
var userClaims = new List<Claim>()
{
    new Claim(ClaimTypes.Name, user.Firstname),
    new Claim(ClaimTypes.Email, users.Email)

};

var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

var userPrinciple = new ClaimsPrincipal(new[] { grandmaIdentity });
HttpContext.SignInAsync(userPrinciple);

return RedirectToAction("Index", "Home");
}
return View(user);
}*/

        [HttpPost]
        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
                HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }










































        // Check if Username, email, and phone number exist

        [HttpPost]
        public JsonResult EmailIsAlreadySigned(string UserEmailId) => Json(EmailIsUserAvailable(UserEmailId));
        public bool EmailIsUserAvailable(string EmailId)
        {
            List<Accounts> RegisterUsers = new List<Accounts>()
        {
                new Accounts
                {
                    Username = "johndoe420",
                    Email = "jonnyd120@gmail.com",
                    Phonenumber = "4051238967",
                    Firstname = "John",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "johndoe42069",
                    RoleId = 1
                },
                new Accounts
                {
                    Username = "janedoe420",
                    Email = "jand120@gmail.com",
                    Phonenumber = "4051239967",
                    Firstname = "Jane",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "janedoe42069",
                    RoleId = 1
                }

        };
            var RegEmailId = (from u in accountRepository.Accounts where u.Email.ToUpper() == EmailId.ToUpper() select new { EmailId }).FirstOrDefault();
            bool status;
            if (RegEmailId != null)
                status = false;
            else
                status = true;
            return status;
        }
        [HttpPost]
        public JsonResult UsernameIsAlreadySigned(string UsernameId) => Json(UsernameIsUserAvailable(UsernameId));
        public bool UsernameIsUserAvailable(string UsernameId)
        {
            List<Accounts> RegisterUsers = new List<Accounts>()
        {
                new Accounts
                {
                    Username = "johndoe420",
                    Email = "jonnyd120@gmail.com",
                    Phonenumber = "4051238967",
                    Firstname = "John",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "johndoe42069",
                    RoleId = 1
                },
                new Accounts
                {
                    Username = "janedoe420",
                    Email = "jand120@gmail.com",
                    Phonenumber = "4051239967",
                    Firstname = "Jane",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "janedoe42069",
                    RoleId = 1
                }
        };
            var RegUsernameId = (from u in accountRepository.Accounts where u.Username.ToUpper() == UsernameId.ToUpper() select new { UsernameId }).FirstOrDefault();
            bool status;
            if (RegUsernameId != null)
                status = false;
            else
                status = true;
            return status;
        }
        [HttpPost]
        public JsonResult PhoneIsAlreadySigned(string PhoneId) => Json(PhoneIsUserAvailable(PhoneId));
        public bool PhoneIsUserAvailable(string PhoneId)
        {
            List<Accounts> RegisterUsers = new List<Accounts>()
        {
                new Accounts
                {
                    Username = "johndoe420",
                    Email = "jonnyd120@gmail.com",
                    Phonenumber = "4051238967",
                    Firstname = "John",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "johndoe42069",
                    RoleId = 1
                },
                new Accounts
                {
                    Username = "janedoe420",
                    Email = "jand120@gmail.com",
                    Phonenumber = "4051239967",
                    Firstname = "Jane",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "janedoe42069",
                    RoleId = 1
                }
        };
            var RegPhoneId = (from u in accountRepository.Accounts where u.Phonenumber.ToUpper() == PhoneId.ToUpper() select new { PhoneId }).FirstOrDefault();
            bool status;
            if (RegPhoneId != null)
                status = false;
            else
                status = true;
            return status;
        }
    }
}