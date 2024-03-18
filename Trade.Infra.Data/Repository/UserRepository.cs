using Trade.Domain.Entities;
using Trade.Domain.Interfaces.Repository;

namespace Trade.Infra.Data.Repository
{
    public class UserRepository(IMongoDbSettings settings) : MongoRepository<User>(settings), IUserRepository
    {
    }
}
