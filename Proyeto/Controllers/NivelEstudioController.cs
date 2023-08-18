using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    [Authorize]
    public class NivelEstudioController : Controller
    {
        NivelEstudioDatos _nivelDatos = new NivelEstudioDatos();
        // GET: NivelEstudioController
        public ActionResult Index()
        {
            List<NivelEstudioModel>  lista = _nivelDatos.Listar();
            return View(lista);
        }

        // GET: NivelEstudioController/Details/5
        public ActionResult Details(int id)
        {
            NivelEstudioModel nivel = _nivelDatos.Obtener(id);

            return View(nivel);
        }

        // GET: NivelEstudioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NivelEstudioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("NombreNivel")] NivelEstudioModel nivel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nivelDatos.Guardar(nivel);

                    return RedirectToAction(nameof(Index));
                }
                return View(nivel);
            }
            catch
            {
                return View();
            }
        }

        // GET: NivelEstudioController/Edit/5
        public ActionResult Edit(int id)
        {
            NivelEstudioModel nivel = _nivelDatos.Obtener(id);

            return View(nivel);
        }

        // POST: NivelEstudioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("NivelEstudiosId,NombreNivel")] NivelEstudioModel nivel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nivelDatos.Editar(nivel);

                    return RedirectToAction(nameof(Index));
                }
                return View(nivel);
            }
            catch
            {
                return View();
            }
        }

        // GET: NivelEstudioController/Delete/5
        public ActionResult Delete(int id)
        {
            NivelEstudioModel nivel = _nivelDatos.Obtener(id);

            return View(nivel);
        }

        // POST: NivelEstudioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("NivelEstudiosId,NombreNivel")] NivelEstudioModel nivel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nivelDatos.Eliminar(id);

                    return RedirectToAction(nameof(Index));
                }
                return View(nivel);
            }
            catch
            {
                return View();
            }
        }
    }
}
