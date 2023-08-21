using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyeto.datos;
using Proyeto.Models;

namespace Proyeto.Controllers
{
    public class datosCompletosController : Controller
    {
        //private readonly SisCadticContext _context;
        AutorDatos _autorDatos = new AutorDatos();

        public datosCompletosController()
        {
           
        }

        // GET: datosCompletos
        public async Task<IActionResult> Index()
        {
            int autorId = 0;
            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                 autorId = Convert.ToInt32(claimUser.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault());
                
            }

            AutorModel _autor = _autorDatos.Obtener(autorId);
            
            return View(_autor);
        }

        // GET: datosCompletos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AutorModel autor = _autorDatos.Obtener((int)id);
            
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // GET: datosCompletos/Create
        public IActionResult Create()
        {
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId");
            return View();
        }

        // POST: datosCompletos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,TipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor)
        {
            if (ModelState.IsValid)
            {
                _autorDatos.Guardar(autor);
                
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId", autor.IdNivelEstudios1);
            return View(autor);
        }

        // GET: datosCompletos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _autorDatos.Obtener((int)id);
            if (autor == null)
            {
                return NotFound();
            }
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId", autor.IdNivelEstudios1);
            return View(autor);
        }

        // POST: datosCompletos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutor,Nombre,ApePaterno,ApeMaterno,Matricula,NumEmpleado,TipoCuenta,NumTelefono,FechaNaci,CuerpoAcademico,AreaEstudios,IdNivelEstudios1")] AutorModel autor)
        {
            if (id != autor.IdAutor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _autorDatos.Editar(autor);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        throw;
                   
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdNivelEstudios1"] = new SelectList(_context.NivelEstudios, "NivelEstudiosId", "NivelEstudiosId", autor.IdNivelEstudios1);
            return View(autor);
        }

        // GET: datosCompletos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _autorDatos.Obtener((int)id);
          
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: datosCompletos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var autor = _autorDatos.Obtener(id);
            if (autor != null)
            {
                _autorDatos.Eliminar(id);
               
            }
            return RedirectToAction(nameof(Index));
        }

       
      
    }
}
