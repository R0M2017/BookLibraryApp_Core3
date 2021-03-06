﻿using System;
using System.Collections.Generic;

namespace BookLibraryApp.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Accounts = new HashSet<Accounts>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
