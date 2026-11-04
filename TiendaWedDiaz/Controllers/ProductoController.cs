using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections;
using System.Diagnostics;
using System.Security.Claims;
using TiendaWedDiaz.Data;
using TiendaWedDiaz.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TiendaWedDiaz.Controllers
{
    public class ProductoController : Controller
    {
        private readonly TiendaContext _context;
        public ProductoController(TiendaContext context)

        {
            _context = context;
        }
        // listar/ traer los productos que tengo en la bd
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var productos = _context.Productos
                .Include(p => p.Categoria)
                .ToList();
            return View(productos);
        }

        // MPOSTRAR EL FORMULARIO PARA CREAR UN NUEVO PRODUCTO
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }
        // GUARDAR EL NUEVO PRODUCTO EN LA BD
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            foreach (var campo in ModelState)
                foreach (var error in campo.Value.Errors)
                    System.Diagnostics.Debug.WriteLine($"CAMPO: {campo.Key} -> {error.ErrorMessage}");
            return View(producto);
        }
        // MOSTRAR EL FORMULARIO PARA EDITAR UN PRODUCTO ESPECIFICO 
        public IActionResult Edit(int id)
        {
            var Producto = _context.Productos.Find(id);
            return View(Producto);
        }

        // ACTUALIZAR EL PRODUCTO EN LA BD
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(producto);
        }
        // ELIMINA UN PRODUCTO EN LA BD
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var Producto = _context.Productos.Find(id);
            _context.SaveChanges();
            return RedirectToAction("index");


        var rol = HttpContext.Session.GetString("Rol");
        //SOLO EL ADMIN PUEDE ELIMINAR PRODUCTOS
        if(rol != "Administrador")
        {
            return RedirectToAction("Index");
        }
        }
    }
}