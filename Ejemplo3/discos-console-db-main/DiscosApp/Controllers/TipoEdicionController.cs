using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using negocio;

namespace DiscosApp.Controllers
{
    public class TipoEdicionController : Controller
    {
        // GET: TipoEdicionController
        public ActionResult Index(string filtro)
        {
            TipoEdicionNegocio edicionNegocio = new TipoEdicionNegocio();
            var tipo = edicionNegocio.listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                tipo = tipo.FindAll(d => d.Descripcion.Contains(filtro));
            }

            ViewBag.filtro = filtro;
            return View(tipo);
        }

        // GET: TipoEdicionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoEdicionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEdicionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoEdicion tipo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                TipoEdicionNegocio negocio = new TipoEdicionNegocio();
                negocio.agregar(tipo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoEdicionController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoEdicionNegocio negocio = new TipoEdicionNegocio();
            var tipo = negocio.listar().Find(te => te.Id == id);

            return View(tipo);
        }

        // POST: TipoEdicionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipoEdicion tipo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tipo);
                }
                TipoEdicionNegocio negocio = new TipoEdicionNegocio();
                negocio.modificar(tipo);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoEdicionController/Delete/5
        public ActionResult Delete(int id)
        {
            TipoEdicionNegocio negocio = new TipoEdicionNegocio();
            var tipo = negocio.listar().Find(te => te.Id == id);

            return View(tipo);
        }

        // POST: TipoEdicionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                TipoEdicionNegocio negocio = new TipoEdicionNegocio();
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
