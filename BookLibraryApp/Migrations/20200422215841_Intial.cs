using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibraryApp.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    table.PrimaryKey("PRIMARY", x => x.ISBN);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookratings");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
