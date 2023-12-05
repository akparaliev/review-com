using Microsoft.EntityFrameworkCore;
using ReviewComDAL.Models;

namespace ReviewComDAL.Repository
{
    /// <summary>
    /// CompanyRepository is a class that provides CRUD operation on Company entity in DB,
    /// provides additional methods, like get AVG rating of a company.
    /// </summary>
    /// <param name="context">The context that stores information about entities in ORM</param>
    public class CompanyRepository(ApiContext context) : EfCoreRepository<Company, ApiContext>(context)
    {
        /// <summary>
        /// It returns average rating for specified company.
        /// </summary>
        /// <param name="companyId">The id of company</param>
        /// <returns></returns>
        public async Task<double> GetCompanyAvgRating(int companyId)
        {
            return await context.Set<Review>().Where(review=>review.Company.Id == companyId).Select(review=>review.Performance).AverageAsync();
        }
    }
}