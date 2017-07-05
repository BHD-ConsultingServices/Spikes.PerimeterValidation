
namespace Spike.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Contracts.Books;
    using PerimeterValidation.Validation;
    using StubData.Builders;

    [TestClass]
    public class ObjectValidatorTests
    {
        private readonly ObjectValidator<AddBookRequest> _bookValidator = 
            new ObjectValidator<AddBookRequest>()
                .AddRule(r => r.ReleaseDate.Past(), "Release Date must be in past")
                .AddRule(r => r.Title.Mandatory(),  "Mandatory Title")
                .AddRule(r => r.Author.Mandatory(), "Mandatory Author");


        [TestMethod]
        public void ValidateBookValid()
        {
            var request = new BookBuilder().FiveDysfunctions().BuildAddRequest();
            var result = _bookValidator.Validate(request);

            Console.Write(result);
            Assert.IsTrue(result.IsValid, result.ToString());
        }

        [TestMethod]
        public void ValidateBookInValid()
        {
            var request = new BookBuilder().FiveDysfunctions().BuildAddRequest();
            request.Title = null;
            request.ReleaseDate = DateTime.Now.AddDays(1);

            var result = _bookValidator.Validate(request);

            Console.Write(result);
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(2, result.NumberOfErrors, result.ToString());
        }
    }
}
