
namespace Spike.StubData
{
    using System.Collections.Generic;
    using Contracts.Books;

    public static class StubDatabase
    {
        private static List<Book> _books;

        public static List<Book> Books
        {
            get
            {
                if (_books != null)
                {
                    return _books;
                }

                return _books = new List<Book>();
            }
        }
    }
}
