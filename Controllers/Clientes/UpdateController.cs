using Microsoft.AspNetCore.Mvc;
using NewCelsia.Models;
using NewCelsia.Services.Interfaces;
using System.Threading.Tasks;

namespace NewCelsia.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult EditarCliente(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View("Edit", cliente);
        }

        [HttpPost]
        public IActionResult ActualizarCliente(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _clienteRepository.UpdateBook(id, cliente);
                    return RedirectToAction("GetAllClientes");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al actualizar el cliente: {ex.Message}");
                }
            }
            return View("Edit", cliente);
        }

    }
}
