using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyeto.datos;
using Proyeto.Models;
using Proyeto.Recursos;

namespace Proyeto.Controllers
{
    public class RegistroController : Controller
    {
       UsuarioDatos _usuarioDatos = new UsuarioDatos();
        AutorDatos _autorDatos = new AutorDatos();
        NivelEstudioDatos _nivelesDatos = new NivelEstudioDatos();
        TipoCuentaDatos _datoscuenta = new TipoCuentaDatos();

        public RegistroController()
        {
            
        }

        // GET: Registro
        public async Task<IActionResult> Index()
        {
            var lista = _usuarioDatos.Listar();
       
            return View(lista);
        }

        // GET: Registro/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _usuarioDatos.Obtener(id);
          
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Registro/Create
        public IActionResult Create()
        {
            var listatipos = _datoscuenta.Listar();
            ViewData["IdTipoCuenta"] = new SelectList(listatipos, "IdTipo", "Descripcion");
          
            var lista = _nivelesDatos.Listar();
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");           
            return View();
        }

        // POST: Registro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NombreUsuario,Correo,Contrasena")] UsuarioModel usuario, [Bind("IdTipoCuenta, Nombre, ApePaterno, ApeMaterno, FechaNaci, IdNivelEstudios1, AreaEstudios, NumTelefono")] AutorModel autor, string confcontrasena)
        {
            if (ModelState.IsValid)
            {
                if (_usuarioDatos.ExisteUsuario(usuario.NombreUsuario))
                {
                    ViewData["Mensaje"] = "el usuario ingresado ya se encuentra registrado";
                }
                else
                {
                    if (autor.NumEmpleado > 1 && autor.NumEmpleado <= 1000)
                    {
                        usuario.Rol = (int)RolUsuario.Docente;
                    }
                    else if (autor.NumEmpleado > 1000)
                    {
                        usuario.Rol = (int)RolUsuario.Alumno;
                    }
                    autor = _autorDatos.Guardar(autor);

                    usuario.IdAutor1 = autor.IdAutor;
                    _usuarioDatos.GuardarUsuario(usuario);

                    return RedirectToAction(nameof(Index));
                }
            }
            var listatipos = _datoscuenta.Listar();
            ViewData["IdTipoCuenta"] = new SelectList(listatipos, "IdTipo", "Descripcion");
            //ViewData["IdAutor1"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", usuario.IdAutor1);
            var lista = _nivelesDatos.Listar();
            ViewData["IdNivelEstudios1"] = new SelectList(lista, "NivelEstudiosId", "NombreNivel");
            return View(usuario);
        }

        // GET: Registro/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var usuario = _usuarioDatos.Obtener(id);
            
            if (usuario == null)
            {
                return NotFound();
            }
            //ViewData["IdAutor1"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", usuario.IdAutor1);
            return View(usuario);
        }

        // POST: Registro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NombreUsuario,Correo,Contrasena,IdAutor1")] UsuarioModel usuario)
        {
            if (id != usuario.NombreUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioDatos.Editar(usuario);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
               
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdAutor1"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", usuario.IdAutor1);
            return View(usuario);
        }

        // GET: Registro/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _usuarioDatos.Obtener(id);
            
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = _usuarioDatos.Obtener(id);
            
            if (usuario != null)
            {
                _usuarioDatos.Eliminar(id);
                
            }
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
