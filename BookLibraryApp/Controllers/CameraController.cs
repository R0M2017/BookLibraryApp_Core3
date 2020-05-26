using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BookLibraryApp.Controllers
{
    public class CameraController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public CameraController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Capture()
        {
            return View();
        }

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