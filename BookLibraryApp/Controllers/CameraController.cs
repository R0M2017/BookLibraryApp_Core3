using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryApp.Models.data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MySqlX.XDevAPI.Common;
using Nancy.Json;

namespace BookLibraryApp.Controllers
{
    public class CameraController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public isbnStorage[] isbnStorage;

        public CameraController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Capture()
        {
            return View();
        }

        /*[HttpPost]
        public IActionResult InsertISBN(string isbn)
        {
            System.Diagnostics.Debug.WriteLine("\n\n" + isbn + "\n\n");
            return RedirectToAction("Index", "Books");
        }*/
        /*public JsonResult InsertISBN(string isbn)
        {
            var js = new JavaScriptSerializer();
            isbnStorage = js.Deserialize<isbnStorage[]>(isbn);
            foreach (var i in isbnStorage)
                System.Diagnostics.Debug.WriteLine("\n\n" + i + "\n\n");
                // System.Diagnostics.Debug.WriteLine("\n\n" + isbn + "\n\n");
                return Json("result");
        }*/

      /*  [HttpPost]
        public IActionResult Capture(string name)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var fileName = file.FileName;
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        var filepath = Path.Combine(_environment.WebRootPath, "webcamimg") + $@"\{newFileName}";

                        if (!string.IsNullOrEmpty(filepath))
                            StoreInFolder(file, filepath);

                        *//*
                        var imageBytes = System.IO.File.ReadAllBytes(filepath);

                        if (imageBytes != null)
                            StoreInDatabase(imageBytes);
                            *//*
                    }
                }
                return Json(true);
            }
            else
                return Json(false);
        }

        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }*/

    }
}