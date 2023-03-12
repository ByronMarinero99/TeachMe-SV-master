using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;
using TeachMeLogicaDeNegocio;

namespace TeachMeInterfazGraficaMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class LibrosController : Controller
    {
            LibroBL libroBL = new LibroBL();//metodo de acceso a las clases de BL
            CategoriaBL categoriaBL = new CategoriaBL();

        // Muestra la pagina principald e contactos
        public async Task<IActionResult> Index(Libro pLibro = null)
        {
            if (pLibro == null)
                pLibro = new Libro();
            if (pLibro.top_aux == 0)
                pLibro.top_aux = 10;
            else if (pLibro.top_aux == -1)
                pLibro.top_aux = 0;


            var libro = await libroBL.BuscarIncluirLibroAsync(pLibro);
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Top = pLibro.top_aux;
            return View(libro);
        }

        // GET: LibroController/Details/5
        // accion de muestra de detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var Libro = await libroBL.ObtenerPorIdAsync(new Libro { Id = id });
            Libro.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = Libro.Id });
            return View(Libro);
        }

        // GET: LibroController/Create
        // GET: accion que muestra el formulario
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Error = "";
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            return View();
        }

        // POST: LibroController/Create
        // accion que recibe los datos del formulario para mandar a la bl
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro pLibro)
        {
            try
            {
                int result = await libroBL.CrearAsync(pLibro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
                return View(pLibro);
            }
        }

        // GET: LibroController/Edit/5
        //acccion que muestra los datos de los formularios
        public async Task<IActionResult> Edit(Libro pLibro)
        {
            var libro = await libroBL.ObtenerPorIdAsync(pLibro);
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Error = "";
            return View(libro);
        }

        // POST: LibroController/Edit/5
        // accion que recibe los datois modificados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro pLibro)
        {
            try
            {
                int result = await libroBL.ModificarAsync(pLibro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
                return View(pLibro);
            }
        }

        // GET: LibroController/Delete/5
        // muestra pagina para confirmar la eliminacion
        public async Task<IActionResult> Delete(Libro pLibro)
        {
            ViewBag.Error = "";
            var libro = await libroBL.ObtenerPorIdAsync(pLibro);
            libro.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = pLibro.Id });
            return View();
        }

        // POST: LibroController/Delete/5
        // accion que recive la confirnmacion para eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Libro pLibro)
        {
            try
            {
                int result = await libroBL.EliminarAsync(pLibro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            var Libro = await libroBL.ObtenerPorIdAsync(pLibro);
            if (Libro == null)
                Libro = new Libro();

                if (Libro.Id > 0)
                    Libro.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = pLibro.Id });
                return View(pLibro);
            }

        }



    }
}
