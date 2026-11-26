using Microsoft.AspNetCore.Mvc;
using Pásalo.Data;

namespace Pásalo.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticulosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articulos = _context.Articulos.ToList();

            return View(articulos);
        }
    }
}