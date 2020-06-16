﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryApp.Models;
using BookLibraryApp.Models.Pages;
using Nancy.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Json.Net;

namespace BookLibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private IRepository repository;
        public BooksController(IRepository repo) => repository = repo;
        public IActionResult Index(QueryOptions options)
        {
            return View(repository.GetBooks(options));
        }
        [HttpPost]
        public IActionResult AddBook(Books book)
        {
            repository.AddBook(book);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateBook(int bookid) => View(repository.GetBook(bookid));
        [HttpPost]
        public IActionResult UpdateBook(Books book)
        {
            repository.UpdateBook(book);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateAll()
        {
            ViewBag.UpdateAll = true;
            return View(nameof(Index), repository.Books);
        }
        [HttpPost]
        public IActionResult UpdateAll(Books[] books)
        {
            repository.UpdateAll(books);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(Books book)
        {
            repository.Delete(book);
            return RedirectToAction(nameof(Index));
        }

        public void IsbnDbApi()
        {
            const string WEBSERVICE_URL = "https://api2.isbndb.com/book/9781934759486";
            try
            {
                var webRequest = WebRequest.Create(WEBSERVICE_URL);

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.ContentType = "application/json";
                    webRequest.Headers["Authorization"] = "44174_37ec3ba969f1f505eb0f2d6ae51b079a";

                    WebResponse wr = webRequest.GetResponseAsync().Result;
                    Stream receiveStream = wr.GetResponseStream();
                    StreamReader reader = new StreamReader(receiveStream);

                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        
    }
}
