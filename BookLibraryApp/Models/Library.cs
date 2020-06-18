using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibraryApp.Models
{
    public partial class Library
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibraryId { get; set; }
        public int AccountId { get; set; }
        public int BookId { get; set; }
        public DateTime Datecreated { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Books Book { get; set; }
    }
}
