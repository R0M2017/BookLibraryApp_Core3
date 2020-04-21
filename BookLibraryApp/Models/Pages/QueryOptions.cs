using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models.Pages
{
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 16;
    }
}
