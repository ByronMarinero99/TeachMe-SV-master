using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public class ComprasController : Controller
    {
        CompraBL compraBL = new CompraBL();
        UsuarioBL usuarioBL = new UsuarioBL();
        CursoBL cursoBL = new CursoBL();
        CredencialPagoBL credencialPagoBL = new CredencialPagoBL();

        // Accion que muestra la pagina principal de empresas
        public async Task<IActionResult> Index(Compra pCompra = null)
        {
            if (pCompra == null)
                pCompra = new Compra();
            if (pCompra.top_aux == 0)
                pCompra.top_aux = 0;
            else if (pCompra.top_aux == -1)
                pCompra.top_aux = 0;

            var compra = await compraBL.BuscarIncluiEstudianteAsync(pCompra);
            ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Cursos = await cursoBL.ObtenerTodosAsync();
            ViewBag.CredencialPagos = await credencialPagoBL.ObtenerTodosAsync();
            ViewBag.Top = pCompra.top_aux;
            return View(compra);
        }

        // GET: Compras/Details/5
        // Opcion que muestra los detalles de un registro
        public async Task<IActionResult> Details(int id)
        {
            var compra = await compraBL.obtenerPorId(new Compra { Id = id });
            compra.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = compra.Id });
            compra.Curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = compra.Id });
            compra.CredencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = compra.Id });
            return View(compra);
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

        // Accion que recibe los datos del formulario y los envia a la BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Compra pCompra)
        {
            try
            {
                int result = await compraBL.CrearAsync(pCompra);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuario = await usuarioBL.ObtenerTodosAsync();
                ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
                ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
                return View(pCompra);
            }
        }

        // Accion que muestra los adtos del registro cargados en el formulario
        public async Task<IActionResult> Edit(Compra pCompra)
        {
            var compra = await compraBL.obtenerPorId(pCompra);
            ViewBag.Usuario = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
            ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View(compra);
        }

        // accion que recibe los datos modificados para enviarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Compra pCompra)
        {
            try
            {
                int result = await compraBL.ModificarAsync(pCompra);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuario = await usuarioBL.ObtenerTodosAsync();
                ViewBag.Curso = await cursoBL.ObtenerTodosAsync();
                ViewBag.CredencialPago = await credencialPagoBL.ObtenerTodosAsync();
                return View(pCompra);
            }
        }

        // Accion que muestra los datos del registro para confrimar la eliminacion
        public async Task<IActionResult> Delete(Compra pCompra)
        {
            var compra = await compraBL.obtenerPorId(pCompra);
            compra.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = pCompra.IdUsuario });
            compra.Curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = pCompra.IdCurso });
            compra.CredencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = pCompra.IdCredencialesPagos });
            ViewBag.Error = "";
            return View();
        }

        // Accion que recibe para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Compra pCompra)
        {
            try
            {
                int result = await compraBL.EliminarAsync(pCompra);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var Compra = await compraBL.obtenerPorId(pCompra);
                if (Compra == null)
                    Compra = new Compra();
                if (Compra.Id > 0)
                    Compra.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = pCompra.IdUsuario });
                if (Compra.Id > 0)
                    Compra.Curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = pCompra.IdCurso });
                if (Compra.Id > 0)
                    Compra.CredencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = pCompra.IdCredencialesPagos });
                return View(Compra);
            }
        }
    }
}
