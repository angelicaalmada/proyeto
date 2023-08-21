using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Proyeto.Controllers
{
    [Authorize]
    public class EstudiosRealizadosController : Controller
    {
     
        EstudiosRealizadosDatos _datos = new EstudiosRealizadosDatos();
        private IHostingEnvironment Environment;
        public EstudiosRealizadosController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult Index()
        {
            List<EstudiosRealizadosModel> lista = _datos.Listar();
            return View(lista);
        }

        public ActionResult Crear()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(IFormFile Archivo, [Bind("Matri_NoEmpl, NombreCurso, Duracion, Institucion, Descripcion, UrlDocumento, IdAutor1")] EstudiosRealizadosModel estudiosRealizados)
        {
            try
            {
                string rutasitio = this.Environment.WebRootPath;
                string uploads = Path.Combine(rutasitio, "uploads");
                Random rnd = new Random();
                int r = rnd.Next();
                string nombreArchivo = r.ToString() + "_" + Archivo.FileName;
                string filePath = Path.Combine(uploads, nombreArchivo);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Archivo.CopyToAsync(fileStream);
                }
                estudiosRealizados.UrlDocumento = "/uploads/" + nombreArchivo;

               
                ClaimsPrincipal claimUser = HttpContext.User;
                if (claimUser.Identity.IsAuthenticated)
                {
                    string autorId = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                    estudiosRealizados.IdAutor1 = Convert.ToInt32(autorId);
                }

                if (ModelState.IsValid)
                {
                    _datos.Guardar(estudiosRealizados);

                    return RedirectToAction(nameof(Index));
                }
                return View(estudiosRealizados);
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Detalle(int id)
        {
            EstudiosRealizadosModel estudiosRealizados = _datos.Obtener(id);

            return View(estudiosRealizados);
        }

        
        
        public ActionResult Editar(int id)
        {
            EstudiosRealizadosModel estudiosRealizados = _datos.Obtener(id);

            return View(estudiosRealizados);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(IFormFile Archivo, int id, [Bind("IdEstudiosRealizados, Matri_NoEmpl, NombreCurso, Duracion, Institucion, Descripcion, UrlDocumento, IdAutor1")] EstudiosRealizadosModel estudiosRealizados)
        {
            try
            {
                if (Archivo != null)
                {
                    string rutasitio = this.Environment.WebRootPath;
                    string uploads = Path.Combine(rutasitio, "uploads");
                    Random rnd = new Random();
                    int r = rnd.Next();
                    string nombreArchivo = r.ToString() + "_" + Archivo.FileName;
                    string filePath = Path.Combine(uploads, nombreArchivo);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Archivo.CopyToAsync(fileStream);
                    }
                    estudiosRealizados.UrlDocumento = "/uploads/" + nombreArchivo;
                }
                ModelState.Remove("Archivo");

                if (ModelState.IsValid)
                {
                    _datos.Editar(estudiosRealizados);

                    return RedirectToAction(nameof(Index));
                }
                return View(estudiosRealizados);
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Eliminar(int id)
        {
            EstudiosRealizadosModel estudiosRealizados = _datos.Obtener(id);

            return View(estudiosRealizados);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, [Bind("IdEstudiosRealizados, Matri_NoEmpl, NombreCurso, Duracion, Institucion, Descripcion, UrlDocumento, IdAutor1")] EstudiosRealizadosModel estudiosRealizados)
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
