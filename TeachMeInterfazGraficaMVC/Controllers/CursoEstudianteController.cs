using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;
using TeachMeLogicaDeNegocio;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TeachMeInterfazGraficaMVC.Controllers
{
    public class CursoEstudianteController : Controller
    {
        CursoBL cursoBL = new CursoBL();//metodo de acceso a las clases de BL
        CategoriaBL categoriaBL = new CategoriaBL();

        // Muestra la pagina principal de Curso
        public async Task<IActionResult> Index(Curso pCurso = null)
        {
            if (pCurso == null)
                pCurso = new Curso();
            if (pCurso.top_aux == 0)
                pCurso.top_aux = 10;
            else if (pCurso.top_aux == -1)
                pCurso.top_aux = 0;


            var curso = await cursoBL.BuscarIncluirCategoriaAsync(pCurso);
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Top = pCurso.top_aux;
            return View(curso);
        }

        // accion de muestra de detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var curso = await cursoBL.ObtenerPorIdAsync(new Curso { Id = id });
            curso.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = curso.Id });
            return View(curso);
        }


        // GET: accion que muestra el formulario
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // accion que recibe los datos del formulario para mandar a la bl
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso pCurso)
        {
            try
            {
                int result = await cursoBL.CrearAsync(pCurso);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
                return View(pCurso);
            }
        }

        //acccion que muestra los datos de los formularios
        public async Task<IActionResult> Edit(Curso pCurso)
        {
            var curso = await cursoBL.ObtenerPorIdAsync(pCurso);
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Error = "";
            return View(curso);
        }

        // accion que recibe los datos modificados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Curso pCurso)
        {
            try
            {
                int result = await cursoBL.ModificarAsync(pCurso);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
                return View(pCurso);
            }
        }

        // muestra pagina para confirmar la eliminacion
        public async Task<IActionResult> Delete(Curso pCurso)
        {
            ViewBag.Error = "";
            var curso = await cursoBL.ObtenerPorIdAsync(pCurso);
            curso.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = pCurso.Id });
            return View();
        }

        // accion que recive la confirnmacion para eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Curso pCurso)
        {
            try
            {
                int result = await cursoBL.EliminarAsync(pCurso);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var Curso = await cursoBL.ObtenerPorIdAsync(pCurso);
                if (Curso == null)
                    Curso = new Curso();

                if (Curso.Id > 0)
                    Curso.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = pCurso.Id });
                return View(pCurso);
            }
        }
    }
}
