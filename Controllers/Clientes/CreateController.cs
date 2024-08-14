using Microsoft.AspNetCore.Mvc;
using NewCelsia.Models;
using NewCelsia.Services.Interfaces;
using System.Threading.Tasks;

namespace NewCelsia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente, [FromQuery] string password)
        {
            try
            {
                _clienteRepository.CrearCliente(cliente, password);
                return Ok("Cliente creado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el cliente: {ex.Message}");
            }
        }
    }
}
