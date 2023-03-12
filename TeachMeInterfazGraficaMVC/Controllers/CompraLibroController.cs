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
    public class CompraLibroController : Controller
    {
        CompraLibroBL compraLibroBL = new CompraLibroBL();
        UsuarioBL usuarioBL = new UsuarioBL();
        CursoBL cursoBL = new CursoBL();
        CredencialPagoBL credencialPagoBL = new CredencialPagoBL();

        // Accion que muestra la pagina principal de empresas
        public async Task<IActionResult> Index(CompraLibro pCompraLibro = null)
        {
            if (pCompraLibro == null)
                pCompraLibro = new CompraLibro();
            if (pCompraLibro.top_aux == 0)
                pCompraLibro.top_aux = 0;
            else if (pCompraLibro.top_aux == -1)
                pCompraLibro.top_aux = 0;

            var compraLibro = await compraLibroBL.BuscarIncluiEstudianteAsync(pCompraLibro);
            ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Cursos = await cursoBL.ObtenerTodosAsync();
            ViewBag.CredencialesPagos = await credencialPagoBL.ObtenerTodosAsync();
            ViewBag.Top = pCompraLibro.top_aux;
            return View(compraLibro);
        }

        // Opcion que muestra los detalles de un registro
        public async Task<IActionResult> Details(int id)
        {
            var compraLibro = await compraLibroBL.obtenerPorId(new CompraLibro { Id = id });
            compraLibro.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = compraLibro.Id });
            compraLibro.Curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = compraLibro.Id });
            compraLibro.CredencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = compraLibro.Id });
            return View(compraLibro);
        }

        // Acion que muestra el formulrio para crear una nueva empresa
        public async Task<IActionResult> Create()
        {
            ViewBag.Usuario = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
            ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: CompraLibro/Create
        // Accion que recibe los datos del formulario y los envia a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompraLibro pCompraLibro)
        {
            try
            {
                int result = await compraLibroBL.CrearAsync(pCompraLibro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuario = await usuarioBL.ObtenerTodosAsync();
                ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
                ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
                return View(pCompraLibro);
            }
        }

        // GET: CompraLibro/Edit/5
        // Accion que muestra los adtos del registro cargados en el formulario
        public async Task<IActionResult> Edit(CompraLibro pCompraLibro)
        {
            var compraLibro = await compraLibroBL.obtenerPorId(pCompraLibro);
            ViewBag.Estudiante = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
            ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View(compraLibro);
        }

        // POST: CompraLibro/Edit/5
        // accion que recibe los datos modificados para enviarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompraLibro pCompraLibro)
        {
            try
            {
                int result = await compraLibroBL.ModificarAsync(pCompraLibro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuario = await usuarioBL.ObtenerTodosAsync();
                ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
                ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
                return View(pCompraLibro);
            }
        }

        // Accion que muestra los datos del registro para confrimar la eliminacion
        public async Task<IActionResult> Delete(CompraLibro pCompraLibro)
        {
            var compra = await compraLibroBL.obtenerPorId(pCompraLibro);
            compra.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = pCompraLibro.Id });
            compra.Curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = pCompraLibro.Id });
            compra.CredencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = pCompraLibro.Id });
            ViewBag.Error = "";
            return View();
        }

        // Accion que recibe para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CompraLibro pCompraLibro)
        {
            try
            {
                int result = await compraLibroBL.EliminarAsync(pCompraLibro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var CompraLibro = await compraLibroBL.obtenerPorId(pCompraLibro);
                if (CompraLibro == null)
                    CompraLibro = new CompraLibro();
                if (CompraLibro.Id > 0)
                    CompraLibro.Usuario= await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = pCompraLibro.Id });
                if (CompraLibro.Id > 0)
                    CompraLibro.Curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = pCompraLibro.Id });
                if (CompraLibro.Id > 0)
                    CompraLibro.CredencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = pCompraLibro.Id });
                return View(CompraLibro);
            }
        }
    }
}
