using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyeto.datos;
using Proyeto.Models;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Proyeto.Controllers
{
    [Authorize]
    public class MateriaImpartidaController : Controller
    {
        MateriaImpartidaDatos _datos = new MateriaImpartidaDatos();
        AdminMateriaDatos _datosAdminMateria = new AdminMateriaDatos();
        CarreraAdminDatos _carreraDatos = new CarreraAdminDatos();

        private IHostingEnvironment Environment;
        public MateriaImpartidaController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public ActionResult Index()
        {
            List<MateriaImpartidaModel> lista = _datos.Listar();
            return View(lista);
        }



        public ActionResult Crear()
        {
           List<AdminMateriaModel> ladminmateria =  _datosAdminMateria.Listar();
            ViewData["IdMateriaAdmin"] = new SelectList(ladminmateria, "IdAdminMateria", "NombreMat");

            List<CarreraAdminModel> lCarreras = _carreraDatos.Listar();
            ViewData["IdCarrera"] = new SelectList(lCarreras, "IdCaAdmin", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(IFormFile Archivo, [Bind("IdMateria, Matricula, IdCarrera, IdMateriaAdmin, Grupo, FechaCuatri, UrlDocumento, IdAutor1")] MateriaImpartidaModel materiaImpartida)
        {
            try
            {
                materiaImpartida.MateriaAdmin = new AdminMateriaModel { IdAdminMateria = materiaImpartida.IdMateriaAdmin };
                materiaImpartida.CarreraModel = new CarreraAdminModel { IdCaAdmin = materiaImpartida.IdCarrera };

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
                materiaImpartida.UrlDocumento = "/uploads/" + nombreArchivo;
                ClaimsPrincipal claimUser = HttpContext.User;
                if (claimUser.Identity.IsAuthenticated)
                {
                    string autorId = claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
                    materiaImpartida.IdAutor1 = Convert.ToInt32(autorId);
                }
             
               

                if (ModelState.IsValid)
                {
                    _datos.Guardar(materiaImpartida);
                    return RedirectToAction(nameof(Index));
                }
                return View(materiaImpartida);
            }
            catch
            {
                return View();
            }
        }





        public ActionResult Detalle(int id)
        {
          

            MateriaImpartidaModel materiaImpartida = _datos.Obtener(id);
            return View(materiaImpartida);
        }

        
       

        
        public ActionResult Editar(int id)
        {
            MateriaImpartidaModel materiaImpartida = _datos.Obtener(id);

            List<AdminMateriaModel> ladminmateria = _datosAdminMateria.Listar();
            ViewData["IdMateriaAdmin"] = new SelectList(ladminmateria, "IdAdminMateria", "NombreMat", materiaImpartida.MateriaAdmin.IdAdminMateria);

            List<CarreraAdminModel> lCarreras = _carreraDatos.Listar();
            ViewData["IdCarrera"] = new SelectList(lCarreras, "IdCaAdmin", "Nombre", materiaImpartida.CarreraModel.IdCaAdmin);

            
            return View(materiaImpartida);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(IFormFile Archivo, int id, [Bind("IdMateria, Matricula, IdCarrera, IdMateriaAdmin, Grupo, FechaCuatri, UrlDocumento, IdAutor1")] MateriaImpartidaModel materiaImpartida)
        {
            try
            {
                materiaImpartida.MateriaAdmin = new AdminMateriaModel { IdAdminMateria = materiaImpartida.IdMateriaAdmin };
                materiaImpartida.CarreraModel = new CarreraAdminModel {  IdCaAdmin = materiaImpartida.IdCarrera };

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
                    materiaImpartida.UrlDocumento = "/uploads/" + nombreArchivo;
                }
                ModelState.Remove("Archivo");


                if (ModelState.IsValid)
                {
                    _datos.Editar(materiaImpartida);
                    return RedirectToAction(nameof(Index));
                }
                return View(materiaImpartida);
                
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Eliminar(int id)
        {
            MateriaImpartidaModel materiaImpartida = _datos.Obtener(id);
            return View(materiaImpartida);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, [Bind("IdMateria, Matricula, Carrera, Materia, Grupo, FechaCuatri, UrlDocumento, IdAutor1")] MateriaImpartidaModel materiaImpartida)
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
