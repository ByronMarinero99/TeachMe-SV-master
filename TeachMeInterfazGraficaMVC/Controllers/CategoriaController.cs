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
    public class CategoriaController : Controller
    {
        CategoriaBL categoriaBL = new CategoriaBL();//metodo de acceso a las clases de BL


        // Muestra la pagina principald e contactos
        public async Task<IActionResult> Index(Categoria pCategoria = null)
        {
            if (pCategoria == null)
                pCategoria = new Categoria();
            if (pCategoria.top_aux == 0)
                pCategoria.top_aux = 10;
            else if (pCategoria.top_aux == -1)
                pCategoria.top_aux = 0;


            var categoria = await categoriaBL.BuscarAsync(pCategoria);
            ViewBag.Top = pCategoria.top_aux;
            return View(categoria);
        }

        // accion de muestra de detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var admin = await categoriaBL.obtenerPorId(new Categoria { Id = id });
            return View(admin);
        }

        // GET: accion que muestra el formulario
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Administrador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // accion que recibe los datos del formulario para mandar a la bl
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.CrearAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: Administrador/Edit/5
        //acccion que muestra los datos de los formularios
        public async Task<IActionResult> Edit(Categoria pCategoria)
        {
            var admin = await categoriaBL.obtenerPorId(pCategoria);
            ViewBag.Error = "";
            return View(admin);
        }


        // POST: Administrador/Edit/5
        // accion que recibe los datois modificados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.ModificarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: Administrador/Delete/5
        // muestra pagina para confirmar la eliminacion
        public async Task<IActionResult> Delete(Categoria pCategoria)
        {
            ViewBag.Error = "";
            var categoria = await categoriaBL.obtenerPorId(pCategoria);
            return View();
        }

        // POST: Administrador/Delete/5
        // accion que recive la confirnmacion para eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.EliminarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }

        }
    }
}
