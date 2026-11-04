using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaWedDiaz.Data;
using TiendaWedDiaz.Models;

namespace TiendaWedDiaz.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly TiendaContext _context;

        public UsuariosController(TiendaContext context)
        {
            _context = context;
        }

        private void CargarRoles(string? seleccionado = null)
        {
            ViewBag.Roles = new SelectList(Roles.Todos, seleccionado);
        }

        // LISTAR
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuario.OrderBy(u => u.Id).ToListAsync());
        }

        // DETALLE
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // CREAR
        public IActionResult Create()
        {
            CargarRoles();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Correo,Rol,Celular")] Usuario usuario)
        {
            if (await _context.Usuario.AnyAsync(u => u.Correo == usuario.Correo))
                ModelState.AddModelError("Correo", "Ya existe un usuario con este correo");

            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CargarRoles(usuario.Rol);
            return View(usuario);
        }

        // EDITAR
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null) return NotFound();
            CargarRoles(usuario.Rol);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,Rol,Celular")] Usuario usuario)
        {
            if (id != usuario.Id) return NotFound();

            if (await _context.Usuario.AnyAsync(u => u.Correo == usuario.Correo && u.Id != usuario.Id))
                ModelState.AddModelError("Correo", "Ya existe un usuario con este correo");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Usuario.AnyAsync(u => u.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            CargarRoles(usuario.Rol);
            return View(usuario);
        }

        // ELIMINAR
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}