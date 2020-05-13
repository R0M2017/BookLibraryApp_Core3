using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryApp.Controllers
{
    public class CameraController : Controller
    {
        public IActionResult Capture()
        {
            return View();
        }
    }
}