
namespace Spike.Orchestrations
{
    using System;
    using StubData.DAL;
    using Contracts.Books;

    public class BookOrchestration
    {
        [ValidationAspect]
        public Book AddBookRequest(AddBookRequest request, string originatorId)
        {
            var newBook = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                ReleaseDate = request.ReleaseDate
            };

            return StubAdapter.Books.AddBook(newBook);
        }
    }
}
