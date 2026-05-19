using System.Diagnostics;
using Ejemplo7_EF.Data;
using Ejemplo7_EF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo7_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GaleriaDbContext _context;

        public HomeController(ILogger<HomeController> logger, GaleriaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var obras = await _context.Obras
                .Take(3)
                .Include(o => o.Artista)
                .ToListAsync();

            var expo = await _context.Exposiciones.ToListAsync();

            var home = new HomeViewModel { Obras = obras, Exposiciones = expo };

            return View(home);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
