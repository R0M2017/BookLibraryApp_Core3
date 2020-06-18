using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryApp.Models.Pages
{
    public class QueryOptions
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 36;
        public string OrderPropertyName { get; set; }
        public bool DescendingOrder { get; set; }
        public string SearchPropertyName { get; set; }
        public string SearchTerm { get; set; }
        public string SearchIsbnName { get; set; }
        public string SearchIsbnTerm { get; set; }
    }
}
