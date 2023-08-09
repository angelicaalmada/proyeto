using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;
using System.Diagnostics;

namespace Proyeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UsuarioDatos _usuarioDatos = new UsuarioDatos();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
          

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Index(string nombreUsuario, string contrasena)
        {
            UsuarioModel us = _usuarioDatos.Login(nombreUsuario, contrasena);
            //UsuarioModel? us = _context.Usuarios.Where(u => u.NombreUsuario == nombreUs && u.Contrasena == contrasena).FirstOrDefault();
            if (us == null)
            {
                ViewData["msj"] = "Usuario o contraseña invalida";
                return View();
            }
            else
            {
               
                HttpContext.Session.SetString("usuario", us.NombreUsuario);
                HttpContext.Session.SetString("autor", us.IdAutor1.ToString());

                return RedirectToAction("Entrada", "Home");
            }

        }


        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Entrada()
        {         
                return View();
        }

        public IActionResult HistorialAcademico()
        {
            return View();
        }
        public IActionResult ProductoAcademico()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}