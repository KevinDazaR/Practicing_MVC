using Microsoft.AspNetCore.Mvc;
using NewCelsia.Models;
using NewCelsia.Services.Interfaces;
using System.Collections.Generic;

namespace NewCelsia.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        // Vista para listar todos los clientes
        public IActionResult Index()
        {
            var clientes = _clienteRepository.GetAll();
            return View(clientes);
        }

        // Vista para mostrar los detalles de un cliente
        public IActionResult Details(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }
            return View(cliente);
        }

        // Acción para eliminar un cliente por ID (suponiendo que esta acción existe)
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }
            
            _clienteRepository.DeleteBook(id);
            return RedirectToAction("Index");
        }

        // Acción para actualizar un cliente (suponiendo que esta acción existe)
        public IActionResult Edit(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }
            return View(cliente);
        }

        // Acción para obtener todos los clientes en formato JSON
        [HttpGet("api/clientes")]
        public ActionResult<IEnumerable<Cliente>> GetAllClientes()
        {
            try
            {
                var clientes = _clienteRepository.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener los clientes: {ex.Message}");
            }
        }

        // Acción para obtener un cliente por ID en formato JSON
        [HttpGet("api/clientes/{id}")]
        public ActionResult<Cliente> GetClienteById(int id)
        {
            try
            {
                var cliente = _clienteRepository.GetById(id);
                if (cliente == null)
                {
                    return NotFound("Cliente no encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el cliente: {ex.Message}");
            }
        }
    }
}
