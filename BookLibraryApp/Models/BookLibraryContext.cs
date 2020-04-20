using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookLibraryApp.Models
{
    public partial class BookLibraryContext : DbContext
    {
        public BookLibraryContext()
        {
        }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookratings> Bookratings { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=LOTOS123l;database=booklibrarydatabase", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookratings>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Isbn })
                    .HasName("PRIMARY");

                entity.ToTable("bookratings");

                entity.Property(e => e.UserId).HasColumnName("User-ID");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("varchar(13)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.BookRating).HasColumnName("Book-Rating");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PRIMARY");

                entity.ToTable("books");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("varchar(13)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.BookAuthor)
                    .HasColumnName("Book-Author")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.BookTitle)
                    .HasColumnName("Book-Title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ImageUrlL)
                    .HasColumnName("Image-URL-L")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ImageUrlM)
                    .HasColumnName("Image-URL-M")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ImageUrlS)
                    .HasColumnName("Image-URL-S")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.Publisher)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.YearOfPublication).HasColumnName("Year-Of-Publication");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("User-ID");

                entity.Property(e => e.Location)
                    .HasColumnType("varchar(250)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
