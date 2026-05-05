using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using negocio;

namespace DiscosApp.Controllers
{
    public class EstiloController : Controller
    {
        // GET: EstiloController
        public ActionResult Index(string filtro)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            var estilo = estiloNegocio.listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                estilo = estilo.FindAll(d => d.Descripcion.Contains(filtro));
            }

            ViewBag.filtro = filtro;
            return View(estilo);
        }

        // GET: EstiloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EstiloController/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: EstiloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estilo estilo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(estilo);
                }

                EstiloNegocio negocio = new EstiloNegocio();
                negocio.agregar(estilo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstiloController/Edit/5
        public ActionResult Edit(int id)
        {
            EstiloNegocio negocio = new EstiloNegocio();
            var estilo = negocio.listar().Find(e => e.Id == id);

            return View(estilo);
        }

        // POST: EstiloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Estilo estilo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(estilo);
                }
                EstiloNegocio negocio = new EstiloNegocio();
                negocio.modificar(estilo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstiloController/Delete/5
        public ActionResult Delete(int id)
        {
            EstiloNegocio negocio = new EstiloNegocio();
            var estilo = negocio.listar().Find(e => e.Id == id);

            return View(estilo);
        }

        // POST: EstiloController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                EstiloNegocio negocio = new EstiloNegocio();
                negocio.eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
