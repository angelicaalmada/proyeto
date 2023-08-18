using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    public class AdminCarreraController : Controller
    {
        CarreraAdminDatos _AdminCa = new CarreraAdminDatos();
        public IActionResult Index()
        {
            var lista = _AdminCa.Listar();
            //MOSTAR UNA LISTA DE CARRERAS
            return View(lista);
        }

        //GUARDAR

        [HttpGet]
        public IActionResult Crear()
        {
            //PARA MOSTRAR FORMULARIO
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("Nombre")] CarreraAdminModel model)
        {
            //PARA OBTENER LOS DATOS DEL FORMULARIO Y ENVIARLOS
            var respuesta = _AdminCa.GuardarAdminCarrera(model);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IdCaAdmin)
        {
            //PARA OBTENER Y MOSTRAR EL CONTACTO
            CarreraAdminModel _Carrera = _AdminCa.ObtenerAdminCarrera(IdCaAdmin);
            return View(_Carrera);
        }
        [HttpPost]
        public IActionResult Editar([Bind("IdCaAdmin,Nombre")] CarreraAdminModel model)
        {
            //PARA OBTENER LOS DATOS QUE SE EDITARON EN EL FORMULARIIO
            if (ModelState.IsValid)
            {


                var respuesta = _AdminCa.EditarAdminCarrera(model);
                if (respuesta)
                {
                    return RedirectToAction("Index");
                }
                
            }
            return View();
        }

        public IActionResult Eliminar(int IdCaAdmin)
        {
            //PARA OBTENER Y MOSTRAR LA MATERIA
            var _Carrera = _AdminCa.ObtenerAdminCarrera(IdCaAdmin);
            return View(_Carrera);
        }

        [HttpPost]
        public IActionResult Eliminar(CarreraAdminModel model)
        {
            var respuesta = _AdminCa.EliminarAdminCarrera(model.IdCaAdmin);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
