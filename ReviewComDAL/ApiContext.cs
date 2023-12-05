using Microsoft.EntityFrameworkCore;
using ReviewComDAL.Models;

namespace ReviewComDAL {
    public class ApiContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}