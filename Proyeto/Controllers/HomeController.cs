using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyeto.datos;
using Proyeto.Models;
using Proyeto.Recursos;
using System.Diagnostics;
using System.Security.Claims;

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
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);            
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Index(string nombreUsuario, string contrasena)
        {
            contrasena = Utilidad.EncriptarClave(contrasena);
            UsuarioModel us = _usuarioDatos.Login(nombreUsuario, contrasena);
            //UsuarioModel? us = _context.Usuarios.Where(u => u.NombreUsuario == nombreUs && u.Contrasena == contrasena).FirstOrDefault();
            if (us.NombreUsuario == null)
            {
                ViewData["msj"] = "Usuario o contraseña invalida";
                return View();
            }
            else
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, us.NombreUsuario),
                    new Claim(ClaimTypes.NameIdentifier , us.IdAutor1.ToString())
                };
              
                    claims.Add(new Claim(ClaimTypes.Role, ((RolUsuario)us.Rol).ToString()));
               

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties
                    );


                return RedirectToAction("Entrada", "Home");

                //HttpContext.Session.SetString("usuario", us.NombreUsuario);
                //HttpContext.Session.SetString("autor", us.IdAutor1.ToString());
                //HttpContext.Session.SetString("EsAdmin", us.EsAdmin.ToString());
                //if (us.EsAdmin == 1)
                //{
                //    return RedirectToAction("Index", "Usuario");
                //}
                //else
                //{
                //    return RedirectToAction("Entrada", "Home");
                    
                //}
            }

        }
        [Authorize]

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Entrada()
        {         
                return View();
        }
        [Authorize]
        public IActionResult HistorialAcademico()
        {
            return View();
        }
        [Authorize]
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