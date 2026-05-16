using Ejemplo7_EF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo7_EF.Controllers
{
    public class ObraController : Controller
    {
        private readonly GaleriaDbContext _context;

        public ObraController(GaleriaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id, int idExpo)
        {
            ViewBag.idExpo = idExpo;
            var obra = await _context.Obras
                .Include(o => o.Artista)
                .FirstOrDefaultAsync(o => o.Id.ToString() == id);
            return View(obra);
        }
    }
}
