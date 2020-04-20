using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Models;

namespace BookLibraryApp.Controllers
{
    public class BooksController : Controller
    {

        private IRepository repository;
        public BooksController(IRepository repo) => repository = repo;

        public IActionResult Index() => View(repository.Books);

        /*
    // GET: Books
     public async Task<IActionResult> Index()
     {
        // return View(await _context.Books.ToListAsync());
        // return View(await _context.Books.FirstAsync());
     }

     // GET: Books/Details/5
     public async Task<IActionResult> Details(string id)
     {
         if (id == null)
         {
             return NotFound();
         }

         var books = await _context.Books
             .FirstOrDefaultAsync(m => m.Isbn == id);
         if (books == null)
         {
             return NotFound();
         }

         return View(books);
     }
     */
        /*
         // GET: Books/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Books/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Isbn,BookTitle,BookAuthor,YearOfPublication,Publisher,ImageUrlS,ImageUrlM,ImageUrlL")] Books books)
         {
             if (ModelState.IsValid)
             {
                 _context.Add(books);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(books);
         }

         // GET: Books/Edit/5
         public async Task<IActionResult> Edit(string id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var books = await _context.Books.FindAsync(id);
             if (books == null)
             {
                 return NotFound();
             }
             return View(books);
         }

         // POST: Books/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(string id, [Bind("Isbn,BookTitle,BookAuthor,YearOfPublication,Publisher,ImageUrlS,ImageUrlM,ImageUrlL")] Books books)
         {
             if (id != books.Isbn)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(books);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!BooksExists(books.Isbn))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(books);
         }

         // GET: Books/Delete/5
         public async Task<IActionResult> Delete(string id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var books = await _context.Books
                 .FirstOrDefaultAsync(m => m.Isbn == id);
             if (books == null)
             {
                 return NotFound();
             }

             return View(books);
         }

         // POST: Books/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(string id)
         {
             var books = await _context.Books.FindAsync(id);
             _context.Books.Remove(books);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool BooksExists(string id)
         {
             return _context.Books.Any(e => e.Isbn == id);
         }*/

    }
}
