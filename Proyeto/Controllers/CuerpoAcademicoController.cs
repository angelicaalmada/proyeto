/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyeto.datos;
using Proyeto.Models;
using System.Security.Claims;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace Proyeto.Controllers
{
    [Authorize]
    public class CuerpoAcademicoController
    {
        
        
            CuerpoAcademicoDatos _datos = new CuerpoAcademicoDatos();
            private IHostingEnvironment Environment;
            public CuerpoAcademicoController(IHostingEnvironment _environment)
            {
                Environment = _environment;
            }


            public ActionResult Index()
            {
                List<CuerpoAcademicoModel> lista = _datos.Listar();
                return View(lista);
            }

            public ActionResult Crear()
            {
                return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
        public ActionResult Crear()
        {
            List<AdminMateriaModel> ladminmateria = _datosAdminMateria.Listar();
            ViewData["IdMateriaAdmin"] = new SelectList(ladminmateria, "IdAdminMateria", "NombreMat");

            List<CarreraAdminModel> lCarreras = _carreraDatos.Listar();
            ViewData["IdCarrera"] = new SelectList(lCarreras, "IdCaAdmin", "Nombre");
            return View();
        }

        public ActionResult Detalle(int id)
        {
                CuatriModel cuatri = _datos.Obtener(id);
                return View(cuatri);
        }




            public ActionResult Editar(int id)
            {
                CuatriModel cuatri = _datos.Obtener(id);
                return View(cuatri);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Editar(IFormFile Archivo, int id, [Bind("IdCuatrimestre, NombreCuatri, UrlDocumento, IdAutor1")] CuatriModel cuatri)
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
                        cuatri.UrlDocumento = "/uploads/" + nombreArchivo;
                    }
                    ModelState.Remove("Archivo");


                    if (ModelState.IsValid)
                    {
                        _datos.Editar(cuatri);
                        return RedirectToAction(nameof(Index));
                    }
                    return View(cuatri);

                }
                catch
                {
                    return View();
                }
            }


            public ActionResult Eliminar(int id)
            {
                CuatriModel cuatri = _datos.Obtener(id);

                return View(cuatri);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Eliminar(int id, [Bind("IdCuatrimestre, NombreCuatri")] CuatriModel cuatri)
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
}
*/