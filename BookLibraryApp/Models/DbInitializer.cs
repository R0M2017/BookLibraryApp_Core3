using System;
using System.Data;
using System.IO;
using System.Linq;
using LumenWorks.Framework.IO.Csv;

namespace BookLibraryApp.Models
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(
                new StreamReader(
                    File.OpenRead(@"D:\BookDataset.csv")), true))
            {
                csvTable.Load(csvReader);
            }


            /*for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                Console.WriteLine(csvTable.Rows[i][3].ToString() + " ::::: " + csvTable.Rows[i][4].ToString());
            }*/


            context.Database.EnsureCreated();

            // look for any authors
            if (context.Authors.Any())
                return; // DB has been seeded

            var authors = new Author[] { };

            for (int i = 0; i < csvTable.Rows.Count; i++)
            {

                authors = new Author[] {
                    new Author{AuthorId = Convert.ToInt32(csvTable.Rows[i][0]), FirstName = csvTable.Rows[i][3].ToString(), LastName = csvTable.Rows[i][4].ToString()}
                };
                // var books = new Book[csvTable.Rows.Count];
            }
            foreach (Author a in authors)
                context.Authors.Add(a);

            /*            foreach (Book b in books)
                            context.Books.Add(b);*/

            context.SaveChanges();

        }
    }
}
