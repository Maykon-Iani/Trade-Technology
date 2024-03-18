using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade.Domain.Interfaces.Services;

namespace Trade.Technology.Controllers
{
    [Authorize]
    [Route("clientes")]
    public class ClienteController(IClienteService clienteService,
                                   IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly IClienteService _clienteService = clienteService;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        [HttpPost("upload")]
        [DisableRequestSizeLimit]
        public async Task<ActionResult> Upload()
        {
            if (Request.Form.Files.Count == 0) return NoContent();

            await _clienteService.Upload(Request.Form.Files[0], _webHostEnvironment.WebRootPath);

            return Ok();
        }


    }
}
