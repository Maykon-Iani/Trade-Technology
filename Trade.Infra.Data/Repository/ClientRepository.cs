using Trade.Domain.Entities;
using Trade.Domain.Interfaces.Repository;

namespace Trade.Infra.Data.Repository
{
    public class ClientRepository(IMongoDbSettings settings) : MongoRepository<Client>(settings), IClientRepository
    {
    }
}
