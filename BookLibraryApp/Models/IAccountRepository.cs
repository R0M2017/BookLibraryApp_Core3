using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models
{
    public interface IAccountRepository
    {
        IEnumerable<Users> Users { get; set; }
        Users Login(string UserName, string Password);
        void Register(Users users);

    }
}
