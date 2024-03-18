using Microsoft.AspNetCore.Http;
using Trade.Domain.DTOs;
using Trade.Domain.Entities;
using Trade.Domain.Helpers;
using Trade.Domain.Interfaces.Repository;
using Trade.Domain.Interfaces.Services;

namespace Trade.Service.Services
{
    public class ClientService(IClientRepository clienteRepository) : IClienteService
    {
        private readonly IClientRepository _clienteRepository = clienteRepository;

        public async Task Upload(IFormFile file, string webRootPath)
        {
            var filePath = ExcelHelper.SaveFile(file, webRootPath);

            var clientesRequests = ExcelHelper.Import<ClienteDTO>(filePath);

            var listClient = new List<Client>();
            foreach (var clienteRequest in clientesRequests)
            {
                var cliente = new Client(clienteRequest.Nome, clienteRequest.CPF.ToString(), clienteRequest.Endereco, clienteRequest.Cidade, clienteRequest.Estado, clienteRequest.DDD.ToString(), clienteRequest.Telefone.ToString());

                listClient.Add(cliente);
            }

            await _clienteRepository.InsertManyAsync(listClient);
        }

    }
}
