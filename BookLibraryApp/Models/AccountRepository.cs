using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public class AccountRepository : IAccountRepository
    {
        private BookLibraryContext _context;
        public AccountRepository(BookLibraryContext context) => _context = context;
        public IEnumerable<Accounts> Accounts => _context.Accounts.ToArray();

        public Accounts Login(string Username, string Email, string Password)
        {
            return _context.Accounts.First(u => (u.Username == Username || u.Email == Email) && u.Password == Password);
        }
        public void Register(Accounts user)
        {
            _context.Accounts.Add(user);
            _context.SaveChanges();
            System.Diagnostics.Debug.WriteLine("\n\n" + user + "\n\n");
        }

        public int GetID() => _context.Accounts.ToArray().Length;


        /*public Accounts Login(string Username, string Password)
        {
            return _context.Accounts.First(u => u.Username == Username && u.Password == Password);
        }*/



        /*public IEnumerable<Accounts> GetUsers()
        {
            return new List<Accounts>()
            {
                new Accounts
                {
                    AccountId = 1,
                    Username = "johndoe420",
                    Email = "jonnyd120@gmail.com",
                    Phonenumber = "4051238967",
                    Firstname = "John",
                    Lastname = "Doe",
                    Dateofbirth = new DateTime(1998, 08, 11, 23, 49, 0),
                    Datecreated = DateTime.Now,
                    Password = "johndoe42069",
                    RoleId = 1
                }
            };
        }*/
    }
}
