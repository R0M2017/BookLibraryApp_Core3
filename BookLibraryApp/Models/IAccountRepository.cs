using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public interface IAccountRepository
    {
        IEnumerable<Accounts> Accounts { get; }
        //Accounts Login(Accounts user);
        //Accounts Login(string Username, string Password);
        void Register(Accounts user);
        int GetID();
        Accounts GetAccount(int accountID); 
        
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
