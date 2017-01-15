
namespace Spike.StubData.Builders
{
    using System;
    using Contracts.Books;

    public class BookBuilder : Book
    {
        public BookBuilder(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public BookBuilder TheGoal()
        {
            Title = "The Goal";
            Author = "Eliyahu M. Goldratt and Jeff Cox";
            ReleaseDate = new DateTime(1984, 1, 1);

            return this;
        }

        public BookBuilder FiveDysfunctions()
        {
            Title = "Five Dysfuctions";
            Author = "Patrick Lencioni";
            ReleaseDate = new DateTime(2002, 1, 1);

            return this;
        }

        public BookBuilder RemoveAuthor()
        {
            Author = null;

            return this;
        }

        public AddBookRequest BuildAddRequest()
        {
            return new AddBookRequest
            {
                Title = Title,
                Author = Author,
                ReleaseDate = ReleaseDate
            };
        }

        public Book Build()
        {
            return new Book
            {
                Id = Id,
                Title = Title,
                Author = Author,
                ReleaseDate = ReleaseDate
            };
        }
    }
}
