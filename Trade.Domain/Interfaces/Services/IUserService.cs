using Trade.Domain.Entities;

namespace Trade.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string email);
        Task Create(User user);
        string Authenticate(string email, string password);
    }
}
