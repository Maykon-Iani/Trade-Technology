using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trade.Domain.Entities;
using Trade.Domain.Interfaces.Repository;
using Trade.Domain.Interfaces.Services;

namespace Trade.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly string key;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            this.key = configuration.GetSection("JwtKey").ToString();
        }

        public async Task Create(User user)
        {
            await _userRepository.InsertOneAsync(user);
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.FindOneAsync(user => user.Email == email);
        }

        public string Authenticate(string email, string password)
        {

            var user = _userRepository.FindOneAsync(user => user.Email == email && user.Password == password);
            if (user is null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
