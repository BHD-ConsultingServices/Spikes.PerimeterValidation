
namespace Spike.Contracts.Books
{
    using System;
    using PerimeterValidation.Contracts.Attributes;

    public class BookModifyable
    {
        [Mandatory]
        public string Title { get; set; }

        [Mandatory]
        public string Author { get; set; }

        [Mandatory]
        public DateTime ReleaseDate { get; set; }
    }
}
