
using Spike.PerimeterValidation.Common.Security;

namespace Spike.Orchestrations
{
    using System;
    using System.Linq;
    using StubData.DAL;
    using Contracts.Books;
    using PerimeterValidation;
    using PerimeterValidation.Common.Attributes;

    public class BookOrchestration
    {

        [ValidationAspect(IdentityResolverType.Anonymous)]
        public Book AddBookRequest(AddBookRequest request, [Identity]CoreIdentity originatorReference)
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

        [ValidationAspect(IdentityResolverType.Anonymous)]
        public Book GetBook(Guid id, [Identity]CoreIdentity originatorReference)
        {
            return StubAdapter.Books.GetBooks().Single(b => b.Id == id);
        }
    }
}
