
namespace Spike.StubData.DAL
{
    using System.Linq;
    using Contracts.Books;

    public static class StubAdapter
    {
        public static class Books
        {
            public static Book AddBook(Book book)
            {
                StubDatabase.Books.Add(book);
                return book;
            }

            public static Book EditBook(Book newBook)
            {
                var book = StubDatabase.Books.Single(b => b.Id == newBook.Id);
                return book;
            }
        }
    }
}
