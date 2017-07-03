
using Spike.PerimeterValidation.Common.Attributes;

namespace Spike.Contracts.Books
{
    using System;

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
