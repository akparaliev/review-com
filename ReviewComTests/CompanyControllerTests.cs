using Microsoft.AspNetCore.Mvc;
using Moq;
using ReviewCom.Services;
using ReviewCom.Controllers.v1;
using ReviewComDAL;
using ReviewComDAL.Models;
using ReviewComDAL.Repository;
using TechTalk.SpecFlow;
using Xunit;

namespace ReviewComTests {
    [Binding]
    public class CompanyControllerTests
    {
        private readonly ApiContext _context;
        private readonly Mock<CompanyRepository> _mockRepo;
        private readonly Mock<ILoggingService> _mockLogging;

        private readonly List<Review> _reviews; 
        
        public CompanyControllerTests()
        {
            _mockRepo = new Mock<CompanyRepository>(_context);
            _mockLogging = new Mock<ILoggingService>();
            _reviews = new List<Review>();
        }

        [Given("My company has no reviews")]
        public void GivenCompanyWithNoReviews() {
            _context.Companies.Add(new Company() {Id = 4, Name = "Co and Ko"});
        }

        [Given("A new client joined our service")]
        public void GivenClientWithNoReviews() {
            _context.Clients.Add(new Client() {Id = 2, Name = "Frank", Email = "frank@gmail.com"});
        }

        [When("The client left a review")]
        public async Task WhenClientLeftAReview()
        {
            Company coAndKo = _context.Companies.First();
            Client frank = _context.Clients.First();
            _context.Reviews.Add(new Review() {Id = 5, Text = "All good. It was nice experience.", Performance= 4, Client = frank, Company= coAndKo });
        }

        [When("The client left another review")]
        public async Task WhenClientLeftAnotherReview()
        {
            Company coAndKo = _context.Companies.First();
            Client frank = _context.Clients.First();
            _context.Reviews.Add(new Review() {Id = 5, Text = "All was better. It was better than the first time.", Performance= 5, Client = frank, Company= coAndKo });
        }

        [Then("Get an average rating of a company")]
        public async Task WhenSearchingForBreweriesCloseby()
        {
            Company coAndKo = _context.Companies.First();
            Assert.Equal(4.5, await _mockRepo.Object.GetCompanyAvgRating(coAndKo.Id));
        }

    }
}
