using Ficha12.Models;
using Ficha12WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ficha12WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService service;

        public HomeController(IBookService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var books = service.GetAll();
            return View(new BooksViewModel { Books = books });
        }

        /*public IActionResult Index()
        {
            IEnumerable<Book> books = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7240/api/");
                //HTTP GET
                var responseTask = client.GetAsync("books");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var task = result.Content.ReadFromJsonAsync<IEnumerable<Book>>();
                    task.Wait();
                    books = task.Result;
                }
                else //web api sent error response 
                {        
                    books = Enumerable.Empty<Book>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(new BooksViewModel { Books = books });
        }*/


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]        
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {               
                var newBook = service.CreateAsync(book);              
                if(newBook is not null)
                    return RedirectToAction(nameof(Index));
                else
                    return RedirectToAction(nameof(Error));
            }
            else {
                return RedirectToAction(nameof(Error));
            }            
        }

   
        public IActionResult Delete(string isbn)
        {
            var book = service.GetByISBN(isbn);
            if(book is not null)
            {
                service.DeleteByISBNAsync(isbn);
                return RedirectToAction(nameof(Index));
            }
            else {
                return RedirectToAction(nameof(Error));
            }                           
            
        }
    }
}