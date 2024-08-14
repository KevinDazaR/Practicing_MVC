using Microsoft.AspNetCore.Mvc;
using NewCelsia.Models;
using NewCelsia.Services.Interfaces;

namespace NewCelsia.Controllers
{
    public class FacturacionController : Controller
    {
        private readonly IFacturacionRepository _facturacionRepository;

        public FacturacionController(IFacturacionRepository facturacionRepository)
        {
            _facturacionRepository = facturacionRepository;
        }

        // GET: Facturacion
        public IActionResult Index()
        {
            var facturaciones = _facturacionRepository.GetAll();
            return View(facturaciones);
        }

        // GET: Facturacion/Details/id
        public IActionResult Details(int id)
        {
            var factura = _facturacionRepository.GetById(id);
            if (factura == null)
            {
                return NotFound();
            }
            return View(factura);
        }
    }
}
