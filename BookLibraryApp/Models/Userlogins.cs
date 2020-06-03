using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Userlogins
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public virtual Users User { get; set; }
    }
}
