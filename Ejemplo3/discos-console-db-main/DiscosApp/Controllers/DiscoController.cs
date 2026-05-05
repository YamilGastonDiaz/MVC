using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace DiscosApp.Controllers
{
    public class DiscoController : Controller
    {
        // GET: DiscoController
        public ActionResult Index()
        {
            DiscoNegocio negocio = new DiscoNegocio();
            return View(negocio.listar());
        }

        // GET: DiscoController/Details/5
        public ActionResult Details(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();

            var disco = discoNegocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // GET: DiscoController/Create
        public ActionResult Create()
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio edicionNegocio = new TipoEdicionNegocio();

            ViewBag.Estilo = new SelectList(estiloNegocio.listar(), "Id", "Descripcion");
            ViewBag.TipoEdicion = new SelectList(edicionNegocio.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: DiscoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Disco disco)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(disco);
                }

                DiscoNegocio negocio = new DiscoNegocio();
                negocio.agregar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Edit/5
        public ActionResult Edit(int id)
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio edicionNegocio = new TipoEdicionNegocio();
            DiscoNegocio discoNegocio = new DiscoNegocio();

            var disco = discoNegocio.listar().Find(d => d.Id == id);

            if (disco != null)
            {
                ViewBag.Estilo = new SelectList(estiloNegocio.listar(), "Id", "Descripcion", disco.Estilo.Id);
                ViewBag.TipoEdicion = new SelectList(edicionNegocio.listar(), "Id", "Descripcion", disco.TipoEdicion.Id);
            }
           
            return View(disco);
        }

        // POST: DiscoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Disco disco)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(disco);
                }

                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.modificar(disco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DiscoController/Delete/5
        public ActionResult Delete(int id)
        {
            DiscoNegocio discoNegocio = new DiscoNegocio();

            var disco = discoNegocio.listar().Find(d => d.Id == id);
            return View(disco);
        }

        // POST: DiscoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                DiscoNegocio discoNegocio = new DiscoNegocio();
                discoNegocio.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
