using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApp.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=library.db");
    }
}
