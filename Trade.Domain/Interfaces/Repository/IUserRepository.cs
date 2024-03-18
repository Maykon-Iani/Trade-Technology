using Trade.Domain.Entities;

namespace Trade.Domain.Interfaces.Repository
{
    public interface IUserRepository : IMongoRepository<User>
    {
    }
}
