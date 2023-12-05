using Microsoft.EntityFrameworkCore;
using ReviewComDAL.Models;

namespace ReviewComDAL.Repository
{
     public class ReviewRepository : EfCoreRepository<Review, ApiContext>
    {
        public ReviewRepository(ApiContext context):base(context) {
        }
        public async Task<List<Review>> GetAllPaged(int pageNumber, int pageSize)
        {
            return await context.Set<Review>().Skip(pageSize*pageNumber).Take(pageSize).ToListAsync();
        }
    }
}