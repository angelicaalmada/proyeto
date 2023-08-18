using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    public class AdminMateriaController : Controller
    {
        AdminMateriaDatos _datos = new AdminMateriaDatos();


        // GET: 
        public ActionResult Index()
        {
            List<AdminMateriaModel> lista = _datos.Listar();
            return View(lista);
        }

        // GET:
        public ActionResult Detalle(int id)
        {
            AdminMateriaModel materia = _datos.Obtener(id);
            return View(materia);
        }

        // GET: 
        public ActionResult Crear()
        {
            return View();
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind("NombreMat")] AdminMateriaModel materia)
        {

            try

            {
                if (ModelState.IsValid)
                {
                    _datos.Guardar(materia);
                    return RedirectToAction(nameof(Index));
                }
                return View(materia);

            }
            catch
            {
                return View();
            }
        }

        // GET: 
        public ActionResult Editar(int id)
        {
            AdminMateriaModel materiaobtenida = _datos.Obtener(id);
            return View(materiaobtenida);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, [Bind("IdAdminMateria, NombreMat")] AdminMateriaModel materia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _datos.Editar(materia);
                    return RedirectToAction(nameof(Index));
                }
                return View(materia);
                
            }
            catch
            {
                return View();
            }
        }


        // GET: 
        public ActionResult Eliminar(int id)
        {
            AdminMateriaModel materia = _datos.Obtener(id);
            return View(materia);
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, [Bind("IdAdminMateria, NombreMat")] AdminMateriaModel materia)
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
