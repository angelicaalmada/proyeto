using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    [Authorize]
    public class TipoCuentaController : Controller
    {
        TipoCuentaDatos _datos = new TipoCuentaDatos();

        [HttpGet]
        public IActionResult Index()
        {
            List<TipoCuentaModel> lista = _datos.Listar();
            return View(lista); 
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdTipo,Descripcion")] TipoCuentaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _datos.Guardar(categoria);

                    return RedirectToAction(nameof(Index));
                }
                return View(categoria);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            TipoCuentaModel categoria = _datos.Obtener(id);

            return View(categoria);
        }

        // GET: NivelEstudioController/Edit/5
        public ActionResult Edit(int id)
        {
            TipoCuentaModel categoria = _datos.Obtener(id);

            return View(categoria);
        }

        // POST: NivelEstudioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdTipo,Descripcion")] TipoCuentaModel categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _datos.Editar(categoria);

                    return RedirectToAction(nameof(Index));
                }
                return View(categoria);
            }
            catch
            {
                return View();
            }
        }

        // GET: 
        public ActionResult Delete(int id)
        {
            TipoCuentaModel categoria = _datos.Obtener(id);

            return View(categoria);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("IdTipo,Descripcion")] TipoCuentaModel categoria)
        {
            try
            {
               
                    _datos.Eliminar(id);

                    return RedirectToAction(nameof(Index));
               
            }
            catch
            {
                return View();
            }
        }
    }
}
