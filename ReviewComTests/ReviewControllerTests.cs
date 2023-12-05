using Microsoft.AspNetCore.Mvc;
using Moq;
using ReviewCom.Services;
using ReviewCom.Controllers.v1;
using ReviewComDAL;
using ReviewComDAL.Models;
using ReviewComDAL.Repository;
using Xunit;

namespace ReviewComTests {
    public class ReviewControllerTests
    {
        private readonly Mock<ApiContext> _mockContext;
        private readonly Mock<ReviewRepository> _mockRepo;
        private readonly Mock<ILoggingService> _mockLogging;
        private readonly ReviewController _controller;
        public ReviewControllerTests()
        {
            _mockRepo = new Mock<ReviewRepository>(_mockContext);
            _mockLogging = new Mock<ILoggingService>();
            _controller = new ReviewController(_mockRepo.Object, _mockLogging.Object);
        }

        [Fact]
        public async void GetAll_ReturnAllReviews() {
            //Arrange
            _mockRepo.Setup(repo => repo.GetAll()).Returns(Task.FromResult(new List<Review>() { new(), new() }));

            //Act
            var allReviewsAction = await _controller.GetAll();

            //Assert
            var actionResult = Assert.IsType<ActionResult<List<Review>>>(allReviewsAction);
            var reviews = Assert.IsType<List<Review>>(actionResult.Value);
            Assert.Equal(2, reviews.Count);
        }

        [Fact]
        public async void Get_ReturnReviewWithTheSameId() {
            //Arrange
            var firstReviewId = 4;
            var secondReviewId = 5;
            _mockRepo.Setup(repo => repo.Get(firstReviewId)).Returns(Task.FromResult(new Review() { Id = firstReviewId}));
            _mockRepo.Setup(repo => repo.Get(secondReviewId)).Returns(Task.FromResult(new Review() { Id = secondReviewId}));

            //Act
            var reviewAction = await _controller.Get(firstReviewId);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Review>>(reviewAction);
            var review = Assert.IsType<Review>(actionResult.Value);
            Assert.Equal(4, review.Id);
        }

        [Fact]
        public async void Get_ReturnNotFound() {
            //Arrange
            var id = 4;
            _mockRepo.Setup(repo => repo.Get(id)).Returns(Task.FromResult(new Review() { Id = id}));

            //Act
            var reviewAction = await _controller.Get(5);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Review>>(reviewAction);
            var createdAtActionResult = Assert.IsType<NotFoundResult>(actionResult.Result);
            Assert.Equal(404, createdAtActionResult.StatusCode);
        }
    }
}
