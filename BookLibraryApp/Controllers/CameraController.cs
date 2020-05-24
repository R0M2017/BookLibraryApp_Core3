using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronBarCode;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using ZXing.Presentation;

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

        [HttpPost]
        public IActionResult Capture(string name)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var isbnFilepath = Path.Combine(_environment.WebRootPath, "webcamimg") + $@"\isbn.jpg";

                        if (System.IO.File.Exists(isbnFilepath))
                            System.IO.File.Delete(isbnFilepath);

                        var fileName = file.FileName;
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        var filepath = Path.Combine(_environment.WebRootPath, "webcamimg") + $@"\{newFileName}";

                        if (!string.IsNullOrEmpty(filepath))
                            StoreInFolder(file, filepath);


                        //Spire.Barcode.BarCodeType.EAN13;
                        string[] datas = Spire.Barcode.BarcodeScanner.Scan(filepath);
                        // string data = Spire.Barcode.BarcodeScanner.ScanOne(filepath, true);
                        Console.WriteLine("\n\nThe scanning result is: {0}.", datas[0]);
                        


                        /*string data = Spire.Barcode.BarcodeScanner.ScanOne(filepath, true);
                        Console.WriteLine("\n\nThe scanning result is: {0}.", data);*/

                        /*"https://ironsoftware.com/csharp/barcode"*/

                        /*BarcodeWriter.CreateBarcode(filepath, BarcodeWriterEncoding.PDF417).SaveAsJpeg(isbnFilepath);

                        BarcodeResult result = BarcodeReader.QuicklyReadOneBarcode(isbnFilepath);
                        Console.WriteLine("\n\n" + result + "\n\n");
                        if (result != null && result.Text == filepath)
                            Console.WriteLine("Success");*/

                        /*if (System.IO.File.Exists(filepath))
                            System.IO.File.Delete(filepath);*/

                        /*
                        var imageBytes = System.IO.File.ReadAllBytes(filepath);

                        if (imageBytes != null)
                            StoreInDatabase(imageBytes);
                            */
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
        }


        /*
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            ZXing.BarcodeReader reader = new ZXing.BarcodeReader();
            var result = reader.Decode()
        }

        public Bitmap CreateBitmapSourceFromBitmap(Bitmap bitmap)
        {

        }
        */
    }
}