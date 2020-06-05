using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public class AccountRepository
    {
        private BookLibraryContext _context;
        public AccountRepository(BookLibraryContext context) => _context = context;
        public IEnumerable<Users> Users => _context.Users.ToArray();
        public Users Login(string UserName, string Password)
        {
            return _context.Users.First(u => u.UserName == UserName && u.PasswordHash == Password);
        }

        public void Register(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
