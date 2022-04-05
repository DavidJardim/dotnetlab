using Ficha15.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ficha15.Controllers
{
    public class HomeController : Controller
    {

        private readonly IWebHostEnvironment hostEnvironment;

        public HomeController( IWebHostEnvironment hostEnvironment)
        {      
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Image(ImageUploaded image)
        {
            return View(image);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost("FileUpload")]
        public IActionResult Index(IFormFile file)
        {
            string path = Path.Combine(this.hostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(file.FileName);

            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                file.CopyTo(stream);                
                return RedirectToAction("Image", new ImageUploaded { Path = file.FileName });
            }

            return RedirectToAction("Error");
        }

    }
}