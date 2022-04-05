namespace Ficha12.Models
{
    public interface IBookService
    {
        public abstract IEnumerable<Book> GetAll();

        public Task<Publisher> GetPublisherAsync(string isbn);

        public Task<Book>? GetByISBNAsync(string isbn);

        public Task<Book> CreateAsync(Book newBook);

        public Task DeleteByISBNAsync(string isbn);

        public Task UpdateAsync(string isbn, Book book);

        public Task UpdatePublisherAsync(string isbn, int publisherId);

        public Task UpdateBookPagesAsync(string isbn, int pages);

    }
}
