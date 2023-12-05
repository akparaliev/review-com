using ReviewComDAL.Models;

namespace ReviewComDAL.Repository
{
    public class ClientRepository : EfCoreRepository<Client, ApiContext>
    {
        public ClientRepository(ApiContext context):base(context) {
        }
    }
}