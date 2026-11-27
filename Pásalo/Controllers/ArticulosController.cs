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

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var articulos = _context.Articulos.ToList();

            return View(articulos);
        }

        // GET
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

        // GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var articulo = _context.Articulos.Find(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, [Bind("Nombre,Categoria,Descripcion,Condicion,Ubicacion,Telefono,Disponible")] Articulo articulo)
        {
            var articuloExistente = _context.Articulos.Find(id);

            if (articuloExistente == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                articuloExistente.Nombre = articulo.Nombre;
                articuloExistente.Categoria = articulo.Categoria;
                articuloExistente.Descripcion = articulo.Descripcion;
                articuloExistente.Condicion = articulo.Condicion;
                articuloExistente.Ubicacion = articulo.Ubicacion;
                articuloExistente.Telefono = FormatearTelefono(articulo.Telefono);
                articuloExistente.Disponible = articulo.Disponible;

                _context.SaveChanges();
                TempData["MensajeExito"] = "La donación se ha modificado correctamente.";

                return RedirectToAction(nameof(Index));
            }

            articulo.Id = id;
            return View(articulo);
        }

        // GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var articulo = _context.Articulos.Find(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var articulo = _context.Articulos.Find(id);

            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            _context.SaveChanges();

            TempData["MensajeExito"] = "La donación se ha eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }

        private static string FormatearTelefono(string telefono)
        {
            var digitos = telefono.Replace("-", "");

            return $"{digitos[..3]}-{digitos[3..6]}-{digitos[6..]}";
        }
    }
}