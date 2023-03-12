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
    public class CredencialPagoController : Controller
    {
        CredencialPagoBL credencialPagoBL = new CredencialPagoBL();//metodo de acceso a las clases de BL


        // Muestra la pagina principal de Curso
        public async Task<IActionResult> Index(CredencialPago pCredencialPago = null)
        {
            if (pCredencialPago == null)
                pCredencialPago = new CredencialPago();
            if (pCredencialPago.top_aux == 0)
                pCredencialPago.top_aux = 10;
            else if (pCredencialPago.top_aux == -1)
                pCredencialPago.top_aux = 0;


            var credencialPago = await credencialPagoBL.BuscarAsync(pCredencialPago);
            ViewBag.Top = pCredencialPago.top_aux;
            return View(credencialPago);
        }

        // accion de muestra de detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var credencialPago = await credencialPagoBL.ObtenerPorIdAsync(new CredencialPago { Id = id });
            return View(credencialPago);
        }

        // GET: accion que muestra el formulario
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // accion que recibe los datos del formulario para mandar a la bl
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CredencialPago pCredencialPago)
        {
            try
            {
                int result = await credencialPagoBL.CrearAsync(pCredencialPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCredencialPago);
            }
        }

        //acccion que muestra los datos de los formularios
        public async Task<IActionResult> Edit(CredencialPago pCredencialPago)
        {
            var credencialPago = await credencialPagoBL.ObtenerPorIdAsync(pCredencialPago);
            ViewBag.Error = "";
            return View(credencialPago);
        }

        // accion que recibe los datos modificados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CredencialPago pCredencialPago)
        {
            try
            {
                int result = await credencialPagoBL.ModificarAsync(pCredencialPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCredencialPago);
            }
        }

        // muestra pagina para confirmar la eliminacion
        public async Task<IActionResult> Delete(CredencialPago pCredencialPago)
        {
            ViewBag.Error = "";
            var curso = await credencialPagoBL.ObtenerPorIdAsync(pCredencialPago);
            return View();
        }

        // accion que recive la confirnmacion para eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CredencialPago pCredencialPago)
        {
            try
            {
                int result = await credencialPagoBL.EliminarAsync(pCredencialPago);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCredencialPago);
            }

        }
    }
}
