using Ficha12.Models;
using Microsoft.EntityFrameworkCore;

namespace Ficha12.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryContext context;

        public BookService(LibraryContext context)
        {
            this.context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            var books = context.Books
           .Include(p => p.Publisher);
            return books;            
        }

        public async Task<Publisher> GetPublisherAsync(string isbn)
        {
            var book = await GetByISBNAsync(isbn);
            return book.Publisher;          
        }

        public async Task<Book>? GetByISBNAsync(string isbn)
        {
            var book = await context.Books
            .Include(b => b.Publisher)                
            .SingleOrDefaultAsync(b => b.ISBN == isbn);
            return book;
        }


        public async Task<Book> CreateAsync(Book newBook)
        {
            Publisher pub = await context.Publishers.FindAsync(newBook.Publisher.ID);                 

            if (pub is null)
            {
                throw new NullReferenceException("Publisher does not exist");
            }
            else
            {
                newBook.Publisher = null;//pub;
                await context.Books.AddAsync(newBook);
                await context.SaveChangesAsync();
                return newBook;
            }
        }

        public async Task DeleteByISBNAsync(string isbn)
        {
            var bookToDelete = await context.Books.FindAsync(isbn);
            if (bookToDelete is not null)
            {
                context.Books.Remove(bookToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(string isbn, Book book)
        {
            var bookToUpdate = await context.Books.FindAsync(isbn);
            if (bookToUpdate is null)
            {
                throw new NullReferenceException("Book does not exist");
            }
            else
            {
                Publisher pub = await context.Publishers.FindAsync(book.Publisher.ID);
                bookToUpdate.Title = book.Title;
                bookToUpdate.Pages = book.Pages;
                bookToUpdate.Publisher = pub;
                bookToUpdate.Language = book.Language;
                bookToUpdate.Author = book.Author;

                context.SaveChangesAsync();
            }
        }

        public async Task UpdatePublisherAsync(string isbn, int publisherId)
        {
            var bookToUpdate = await context.Books.FindAsync(isbn);
            var publisherToUpdate = await context.Publishers.FindAsync(publisherId);

            if (bookToUpdate is null || publisherToUpdate is null)
            {
                throw new NullReferenceException("Book or publisher does not exist");
            }

            bookToUpdate.Publisher = publisherToUpdate;

            await context.SaveChangesAsync();
        }

		public async Task UpdateBookPagesAsync(string isbn, int pages)
		{
            var bookToUpdate = await context.Books.FindAsync(isbn);
            bookToUpdate.Pages = pages;
            await context.SaveChangesAsync();
        }
	}
}
