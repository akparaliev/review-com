using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ReviewCom.Controllers;
using ReviewCom.Services;
using ReviewComDAL.Models;
using ReviewComDAL.Repository;

namespace ReviewCom.Controllers.v1
{
    [Route("api/v1/review")]
    [ApiController]
    public class ReviewController: AbstractController<Review, ReviewRepository>
    {
        public ReviewController(ReviewRepository repository, ILoggingService loggingService) : base(repository, loggingService){

        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<List<Review>>> GetAllPaged(int pageNumber, int pageSize)
        {
            loggingService.LogInformation(string.Format("Get all of {0} entries from DB in page {1}", typeof(Review).Name, pageNumber));
            return await repository.GetAllPaged(pageNumber, pageSize);
        }
    }
}