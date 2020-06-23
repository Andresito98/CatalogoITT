using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogoITT.Data;
using CatalogoITT.Models;
using Microsoft.AspNetCore.Http;

namespace CatalogoITT.Controllers
{
    public class LibroController : Controller
    {
        private readonly LibroContext _context;

        public LibroController(LibroContext context)
        {
            _context = context;
        }

        // GET: Libro
        public async Task<IActionResult> Index(string searchSelect, string searchText)
        {
            string _inputOption = searchSelect;
            string _inputText = searchText;

            switch (_inputOption)
            {
                case "Titulo":
                    var libroByTitle = _context.Libros
                   .Where(n => n.nombre.Contains(_inputText, StringComparison.OrdinalIgnoreCase))
                   .ToList();

                    if (!libroByTitle.Any())
                    {
                        return View("Error");
                    }
                    
                    return View(libroByTitle);
                    
                case "Autor":
                    var libroByAutor = _context.Libros
                   .Where(n => n.autor.Contains(_inputText, StringComparison.OrdinalIgnoreCase))
                   .ToList();

                    if (!libroByAutor.Any())
                    {
                        return View("Error");
                    }
                    return View(libroByAutor);

                case "Codigo":
                    var libroByCodigo = _context.Libros
                        .Where(n => n.registro_en_siabuk.Equals(_inputText)).ToList();

                    if (!libroByCodigo.Any()) {
                        return View("Error");
                    }
                    return View(libroByCodigo);

            }

            return View("Error");
        }

        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.libro_id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libro/Create
        public IActionResult Create()
        {
            return View();
        }
        // GET:Libro/Error
        public IActionResult Error()
        {
            return View();
        }
        

        // POST: Libro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("libro_id,nombre,autor,edicion,editorial,isbn,paginas,clasificacion,anio_publicacion,registro_en_siabuk,reserva")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // POST: Libro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("libro_id,nombre,autor,edicion,editorial,isbn,paginas,clasificacion,anio_publicacion,registro_en_siabuk,reserva")] Libro libro)
        {
            if (id != libro.libro_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.libro_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .FirstOrDefaultAsync(m => m.libro_id == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.libro_id == id);
        }
    }
}
