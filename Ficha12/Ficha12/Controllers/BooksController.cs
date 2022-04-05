using Ficha12.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service;
        }

        // GET: api/<BooksController>
        [HttpGet("{isbn}/publishers", Name = "GetPublishers")]
        public async Task<Publisher> GetPublisherAsync(string isbn)
        {
            return await service.GetPublisherAsync(isbn);
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return service.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{isbn}", Name = "GetByISBN")]
        public async Task<IActionResult> GetAsync(string isbn)
        {
            Book? book = await service.GetByISBNAsync(isbn);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }            
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Book book)
        {
            if (book != null)
            {
                Book newBook = await service.CreateAsync(book);
                return CreatedAtRoute("GetByISBN", new { isbn = newBook.ISBN}, newBook);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{isbn}")]
        public async Task<IActionResult> PutAsync(string isbn, [FromBody] Book book)
        {
            var bookToUpdate = await service.GetByISBNAsync(isbn);
            if (book is not null && bookToUpdate is not null)
            {
                service.UpdateAsync(isbn, book);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        //https://localhost:7240/api/Books/978-0544003411/publisherId?publisherId=2
        // PATCH api/<BooksController>/5
        [HttpPatch("{isbn}/publisherId")]
        public async Task<IActionResult> PatchAsync(string isbn, int publisherId)
        {
            var bookToUpdate = await service.GetByISBNAsync(isbn);
            if (bookToUpdate is not null)
            {
                await service.UpdatePublisherAsync(isbn, publisherId);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPatch("{isbn}/pages")]
        public async Task<IActionResult> PatchPagesAsync(string isbn, int pages)
		{
            await service.UpdateBookPagesAsync(isbn, pages);
            return Ok();
		}


        // DELETE api/<BooksController>/5
        [HttpDelete("{isbn}")]
        public async Task<IActionResult> DeleteAsync(string isbn)
        {
            var book = await service.GetByISBNAsync(isbn);

            if (book is not null)
            {
                await service.DeleteByISBNAsync(isbn);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }       
    }
}
