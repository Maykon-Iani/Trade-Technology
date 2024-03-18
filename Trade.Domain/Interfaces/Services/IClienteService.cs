using Microsoft.AspNetCore.Http;

namespace Trade.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task Upload(IFormFile file, string webRootPath);
    }
}
