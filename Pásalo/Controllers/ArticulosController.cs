using Microsoft.AspNetCore.Mvc;
using Pásalo.Data;
using Pásalo.Models;

namespace Pásalo.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var articulos = _context.Articulos.ToList();

            return View(articulos);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var articulo = _context.Articulos.Find(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nombre,Categoria,Descripcion,Condicion,Ubicacion,Telefono")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                articulo.Telefono = FormatearTelefono(articulo.Telefono);
                articulo.Disponible = true;

                _context.Articulos.Add(articulo);
                _context.SaveChanges();

                TempData["MensajeExito"] = "La donación se ha publicado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(articulo);
        }

        private static string FormatearTelefono(string telefono)
        {
            var digitos = telefono.Replace("-", "");

            return $"{digitos[..3]}-{digitos[3..6]}-{digitos[6..]}";
        }
    }
}