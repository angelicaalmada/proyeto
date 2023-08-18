using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    [Authorize]
    public class DocumentoController : Controller
    {
        DocumentoDatos _datos = new DocumentoDatos();
        public IActionResult Index()
        {
          List<DocumentoModel> lis =   _datos.Listar();
            return View(lis);
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            DocumentoModel model = _datos.Obtener(id);
            return View(model);
        }


    }
}
