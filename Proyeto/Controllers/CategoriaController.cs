using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDatos _datos = new CategoriaDatos();
        public IActionResult Index()
        {
            List<CategoriaModel> lista = _datos.Listar();
            return View(lista);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("IdCategoria,Descripcion,Tipo")] CategoriaModel categoria)
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
            CategoriaModel categoria = _datos.Obtener(id);

            return View(categoria);
        }

        // GET: NivelEstudioController/Edit/5
        public ActionResult Edit(int id)
        {
            CategoriaModel categoria = _datos.Obtener(id);

            return View(categoria);
        }

        // POST: NivelEstudioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("IdCategoria,Descripcion,Tipo")] CategoriaModel categoria)
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

        // GET: NivelEstudioController/Delete/5
        public ActionResult Delete(int id)
        {
            CategoriaModel categoria = _datos.Obtener(id);

            return View(categoria);
        }

        // POST: NivelEstudioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("IdCategoria,Descripcion,Tipo")] CategoriaModel categoria)
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
