using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaWedDiaz.Data;
using TiendaWedDiaz.Models;

namespace TiendaWedDiaz.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly TiendaContext _context;

        public CategoriaController(TiendaContext context)
        {
            _context = context;
        }

        // LISTAR
        public IActionResult Index()
        {
            return View(_context.Categorias.OrderBy(c => c.Id).ToList());
        }

        // CREAR
        public IActionResult Create()
        {
            return View(new Categoria());
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // EDITAR
        public IActionResult Edit(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // ELIMINAR
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var categoria = _context.Categorias.Find(id);
            if (categoria != null)
            {
                bool tieneProductos = _context.Productos.Any(p => p.CategoriaId == id);
                if (tieneProductos)
                {
                    TempData["Error"] = "No se puede eliminar: la categoría tiene productos asociados.";
                }
                else
                {
                    _context.Categorias.Remove(categoria);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}