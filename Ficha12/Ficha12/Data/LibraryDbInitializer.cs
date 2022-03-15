using Ficha12.Models;

namespace Ficha12.Data
{
    public static class LibraryDbInitializer
    {
        public static void InsertData(LibraryContext context)
        {
            // Adds a publisher
            var publisher = new Publisher
            {
                Name = "Mariner Books"
            };
            context.Publishers.Add(publisher);

            // Adds some books
            context.Books.Add(new Book
            {
                ISBN = "978-0544003415",
                Title = "The Lord of the Rings",
                Author = "J.R.R. Tolkien",
                Language = "English",
                Pages = 1216,
                Publisher = publisher
            });
            context.Books.Add(new Book
            {
                ISBN = "978-0547247762",
                Title = "The Sealed Letter",
                Author = "Emma Donoghue",
                Language = "English",
                Pages = 416,
                Publisher = publisher
            });
            context.Books.Add(new Book
            {
                ISBN = "978-0544003411",
                Title = "1984",
                Author = "George Orwell",
                Language = "English",
                Pages = 1216,
                Publisher = publisher
            });

            // Saves changes
            context.SaveChanges();
        }
    }
}