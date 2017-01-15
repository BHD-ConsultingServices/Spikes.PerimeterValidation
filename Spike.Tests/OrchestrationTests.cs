
namespace Spike.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orchestrations;
    using StubData.Builders;
    using PerimeterValidation.Contracts;

    [TestClass]
    public class OrchestrationTests
    {
        private const string TestOriginatorId = "TestUser01";

        [TestMethod]
        public void AddBookTestSuccess()
        {
            var provider = new BookOrchestration();
            var request = new BookBuilder().FiveDysfunctions().BuildAddRequest();

            var book = provider.AddBookRequest(request, TestOriginatorId);
            Assert.AreEqual(request.Title, book.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddOldBookTestFails()
        {
            var provider = new BookOrchestration();
            var request = new BookBuilder().TheGoal().BuildAddRequest();

            var book = provider.AddBookRequest(request, TestOriginatorId);
            Assert.AreEqual(request.Title, book.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddBookWithoutMandatoryPropertyFails()
        {
            var provider = new BookOrchestration();
            var request = new BookBuilder().FiveDysfunctions().RemoveAuthor().BuildAddRequest();

            var book = provider.AddBookRequest(request, TestOriginatorId);
            Assert.AreEqual(request.Title, book.Title);
        }
    }
}
