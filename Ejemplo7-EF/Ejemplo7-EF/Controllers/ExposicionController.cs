using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejemplo7_EF.Data;
using Ejemplo7_EF.Models;

namespace Ejemplo7_EF.Controllers
{
    public class ExposicionController : Controller
    {
        private readonly GaleriaDbContext _context;

        public ExposicionController(GaleriaDbContext context)
        {
            _context = context;
        }

        // GET: Exposicion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exposiciones.ToListAsync());
        }

        // GET: Exposicion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exposicion = await _context.Exposiciones
                .Include(e => e.ObrasExpuestas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exposicion == null)
            {
                return NotFound();
            }

            return View(exposicion);
        }

        // GET: Exposicion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exposicion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaInicio,FechaFin")] Exposicion exposicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exposicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exposicion);
        }

        // GET: Exposicion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exposicion = await _context.Exposiciones.FindAsync(id);
            if (exposicion == null)
            {
                return NotFound();
            }
            return View(exposicion);
        }

        // POST: Exposicion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaInicio,FechaFin")] Exposicion exposicion)
        {
            if (id != exposicion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exposicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExposicionExists(exposicion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(exposicion);
        }

        // GET: Exposicion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exposicion = await _context.Exposiciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exposicion == null)
            {
                return NotFound();
            }

            return View(exposicion);
        }

        // POST: Exposicion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exposicion = await _context.Exposiciones.FindAsync(id);
            if (exposicion != null)
            {
                _context.Exposiciones.Remove(exposicion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExposicionExists(int id)
        {
            return _context.Exposiciones.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> SelectObras(int id)
        {
            ViewBag.idExpo = id;
            var obras = await _context.Obras
                .Include(o => o.Artista)
                .Where(o => !o.ExposicionesObras.Any(e => e.Id == id))
                .ToListAsync();
            return View(obras);
        }

        [HttpPost]
        public async Task<IActionResult> SelectObras(int expoId, List<Guid>obraIds)
        {
            var expo = _context.Exposiciones
                .Include(e => e.ObrasExpuestas)
                .FirstOrDefault(e => e.Id == expoId);

            
            if (expo == null)
            {
                return NotFound();
            }

            foreach (var id in obraIds)
            {
                var obra = new Obra { Id = id };
                _context.Attach(obra);

                if (expo.ObrasExpuestas == null)
                {
                    expo.ObrasExpuestas = new List<Obra>();
                }

                expo.ObrasExpuestas.Add(obra);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> QuitarObra(int idExpo, Guid idObra)
        {
            var expo = await _context.Exposiciones
                .Where(e => e.Id == idExpo)
                .Include(e => e.ObrasExpuestas)
                .FirstOrDefaultAsync();

            if (expo == null || expo.ObrasExpuestas == null)
            {
                return NotFound();
            }

            var obra = expo.ObrasExpuestas.FirstOrDefault(o => o.Id == idObra);
            expo.ObrasExpuestas.Remove(obra);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = idExpo });
        }
    }
}
