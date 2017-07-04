
namespace Spike.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Orchestrations;
    using StubData.Builders;
    using PerimeterValidation.Contracts;
    using PerimeterValidation.Common.Security;

    [TestClass]
    public class OrchestrationTests
    {
        private static readonly CoreIdentity testOriginator = new CoreIdentity("TestUser01", true);

        [TestMethod]
        public void AddBookTestSuccess()
        {
            var provider = new BookOrchestration();
            var request = new BookBuilder().FiveDysfunctions().BuildAddRequest();

            var book = provider.AddBookRequest(request, testOriginator);
            Assert.AreEqual(request.Title, book.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddOldBookTestFails()
        {
            var provider = new BookOrchestration();
            var request = new BookBuilder().TheGoal().BuildAddRequest();

            var book = provider.AddBookRequest(request, testOriginator);
            Assert.AreEqual(request.Title, book.Title);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddBookWithoutMandatoryPropertyFails()
        {
            var provider = new BookOrchestration();
            var request = new BookBuilder().FiveDysfunctions().RemoveAuthor().BuildAddRequest();

            var book = provider.AddBookRequest(request, testOriginator);
            Assert.AreEqual(request.Title, book.Title);
        }
    }
}
