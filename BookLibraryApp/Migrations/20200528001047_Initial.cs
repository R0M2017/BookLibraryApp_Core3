using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibraryApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "__efmigrationshistory",
                columns: table => new
                {
                    MigrationId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    ProductVersion = table.Column<string>(type: "varchar(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.MigrationId);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    accountID = table.Column<int>(name: "account-ID", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    phonenumber = table.Column<string>(type: "varchar(15)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    firstname = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    lastname = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    dateofbirth = table.Column<DateTime>(type: "date", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    password = table.Column<string>(type: "varchar(40)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    roleid = table.Column<string>(name: "role-id", type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.accountID);
                });

            migrationBuilder.CreateTable(
                name: "bookratings",
                columns: table => new
                {
                    UserID = table.Column<int>(name: "User-ID", nullable: false),
                    ISBN = table.Column<string>(type: "varchar(13)", nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    BookRating = table.Column<int>(name: "Book-Rating", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.UserID, x.ISBN });
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookID = table.Column<int>(name: "book-ID", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<string>(type: "varchar(13)", nullable: false, defaultValueSql: "''")
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_bin"),
                    BookTitle = table.Column<string>(name: "Book-Title", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    BookAuthor = table.Column<string>(name: "Book-Author", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    YearOfPublication = table.Column<uint>(name: "Year-Of-Publication", nullable: true),
                    Publisher = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    ImageURLS = table.Column<string>(name: "Image-URL-S", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_bin"),
                    ImageURLM = table.Column<string>(name: "Image-URL-M", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_bin"),
                    ImageURLL = table.Column<string>(name: "Image-URL-L", type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_bin")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.bookID);
                });

            migrationBuilder.CreateTable(
                name: "library",
                columns: table => new
                {
                    libraryID = table.Column<int>(name: "library-ID", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userID = table.Column<int>(name: "user-ID", nullable: false),
                    bookID = table.Column<int>(name: "book-ID", nullable: false),
                    datecreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_library", x => x.libraryID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleID = table.Column<int>(name: "role-ID", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(25)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<int>(name: "User-ID", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Location = table.Column<string>(type: "varchar(250)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    Age = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.UserID);
                });

            migrationBuilder.CreateIndex(
                name: "role-id",
                table: "accounts",
                column: "role-id");

            migrationBuilder.CreateIndex(
                name: "book-ID",
                table: "library",
                column: "book-ID");

            migrationBuilder.CreateIndex(
                name: "user-ID",
                table: "library",
                column: "user-ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "__efmigrationshistory");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "bookratings");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "library");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
