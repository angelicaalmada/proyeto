using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyeto.datos;
using Proyeto.Models;
using Proyeto.Recursos;

namespace Proyeto.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        UsuarioAutorDatos _datos = new UsuarioAutorDatos();
        AutorDatos _datosAutor = new AutorDatos();
        UsuarioDatos _datosUsuario = new UsuarioDatos();
        NivelEstudioDatos _datosNivel = new NivelEstudioDatos();
        TipoCuentaDatos _datoscuenta = new TipoCuentaDatos();


        public IActionResult Reporte()
        {
           List <UsuarioAutorModel> listaUs = _datos.Consultar();
            return View(listaUs);
        }


        public IActionResult Index()
        {
            List<UsuarioAutorModel> listaUs = _datos.Consultar();
            return View(listaUs);
        }

        public IActionResult Crear()
        {
            var directions = from RolUsuario d in Enum.GetValues(typeof(RolUsuario))
                             select new { ID = (int)d, Name = d.ToString() };
            ViewData["Rol"] = new SelectList(directions, "ID", "Name");
            var listatipos = _datoscuenta.Listar();
            ViewData["IdTipoCuenta"] = new SelectList(listatipos, "IdTipo", "Descripcion");
            var lista = _datosNivel.Listar();          
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");
            return View();
        }

        // POST: datosCompletos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear([Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,IdTipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor, [Bind("NombreUsuario, Correo, Contrasena, Rol, EsAdmin")] UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                if (_datosUsuario.ExisteUsuario(usuario.NombreUsuario))
                {
                    ViewData["Mensaje"] = "el usuario ingresado ya se encuentra registrado";
                }
                else
                { 
                    usuario.Contrasena = Utilidad.EncriptarClave(usuario.Contrasena);
                    //autor.IdNivelEstudios1 = Convert.ToInt32(Request.Form["IdNivelEstudios1"].ToString());
                    autor = _datosAutor.Guardar(autor);

                    usuario.IdAutor1 = autor.IdAutor;
                    _datosUsuario.GuardarUsuario(usuario);

                    return RedirectToAction(nameof(Index));
                }
            }

            var directions = from RolUsuario d in Enum.GetValues(typeof(RolUsuario))
                             select new { ID = (int)d, Name = d.ToString() };
            ViewData["Rol"] = new SelectList(directions, "ID", "Name");
           
            var listatipos = _datoscuenta.Listar();
            ViewData["IdTipoCuenta"] = new SelectList(listatipos, "IdTipo", "Descripcion");
            var lista = _datosNivel.Listar();
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");
            return View(usuario);
        }




        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _datosAutor.Obtener((int)id);
            if (autor == null)
            {
                return NotFound();
            }
            var usuario = _datosUsuario.ObtenerByAutor(autor.IdAutor);
            usuario.Autor = autor;
            usuario.IdAutor1 = autor.IdAutor;

            var directions = from RolUsuario d in Enum.GetValues(typeof(RolUsuario))
                             select new { ID = (int)d, Name = d.ToString() };
            ViewData["Rol"] = new SelectList(directions, "ID", "Name");
            var listatipos = _datoscuenta.Listar();
            ViewData["IdTipoCuenta"] = new SelectList(listatipos, "IdTipo", "Descripcion", autor.IdTipoCuenta);
            var lista = _datosNivel.Listar();
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel", autor.IdNivelEstudios1);

            return View(usuario);
        }

        // POST: datosCompletos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,IdTipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor, [Bind("NombreUsuario, Correo, Contrasena, Rol, EsAdmin")] UsuarioModel usuario)
        {
            if (id != autor.IdAutor)
            {
                return NotFound();
            }

            ModelState.Remove("Contrasena");
            if (ModelState.IsValid)
            {
                try
                {
                    var usResult =  _datosUsuario.Obtener(usuario.NombreUsuario);
                    usResult.Correo = usuario.Correo;

                    _datosAutor.Editar(autor);
                    _datosUsuario.Editar(usResult);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }

            var directions = from RolUsuario d in Enum.GetValues(typeof(RolUsuario))
                             select new { ID = (int)d, Name = d.ToString() };
            ViewData["Rol"] = new SelectList(directions, "ID", "Name");
            var listatipos = _datoscuenta.Listar();
            ViewData["IdTipoCuenta"] = new SelectList(listatipos, "IdTipo", "Descripcion");
            var lista = _datosNivel.Listar();
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId", autor.IdNivelEstudios1);
            return View(usuario);
        }


        public ActionResult Detalle(int id)
        {
            var autor = _datosAutor.Obtener((int)id);
            var usuario = _datosUsuario.ObtenerByAutor(autor.IdAutor);
            usuario.Autor = autor;
            usuario.IdAutor1 = autor.IdAutor;


            return View(usuario);
        }

        public ActionResult Eliminar(int id)
        {
            var autor = _datosAutor.Obtener((int)id);
            var usuario = _datosUsuario.ObtenerByAutor(autor.IdAutor);
            usuario.Autor = autor;
            usuario.IdAutor1 = autor.IdAutor;


            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id, [Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,TipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor)
        {
            try
            {
                UsuarioModel us = _datosUsuario.ObtenerByAutor((int)id);
                bool respuesta = _datosUsuario.Eliminar(us.NombreUsuario);               
                if(respuesta==true)
                {
                    _datosAutor.Eliminar(id);
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public IActionResult CambiarContrasena()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CambiarContrasena(string Correo, string Contrasena)
        {
            bool respuesta = _datosUsuario.CambiarContrasena(Correo, Utilidad.EncriptarClave(Contrasena));
            if (!respuesta)
            {
                ViewData["Mensaje"] = "El correo no existe";
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
