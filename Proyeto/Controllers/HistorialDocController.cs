using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    public class HistorialDocController : Controller
    {
        HistorialDocDatos _HistorialDoc = new HistorialDocDatos();

        public IActionResult Listar()
        {
            var lista = _HistorialDoc.Listar();
            return View(lista);
        }
    }
}
