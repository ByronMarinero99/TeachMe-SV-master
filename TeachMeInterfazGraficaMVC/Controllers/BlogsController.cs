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
    public class BlogsController : Controller
    {
        BlogBL blogBL = new BlogBL();//metodo de acceso a las clases de BL
        CategoriaBL categoriaBL = new CategoriaBL();

        // Muestra la pagina principal de Curso
        public async Task<IActionResult> Index(Blog pBlog = null)
        {
            if (pBlog == null)
                pBlog = new Blog();
            if (pBlog.top_aux == 0)
                pBlog.top_aux = 10;
            else if (pBlog.top_aux == -1)
                pBlog.top_aux = 0;


            var blog = await blogBL.BuscarIncluirCategoriaAsync(pBlog);
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Top = pBlog.top_aux;
            return View(blog);
        }

        // accion de muestra de detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var blog = await blogBL.ObtenerPorIdAsync(new Blog { Id = id });
            blog.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = blog.Id });
            return View(blog);
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
        public async Task<IActionResult> Create(Blog pBlog)
        {
            try
            {
                int result = await blogBL.CrearAsync(pBlog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
                return View(pBlog);
            }
        }

        //acccion que muestra los datos de los formularios
        public async Task<IActionResult> Edit(Blog pBlog)
        {
            var blog = await blogBL.ObtenerPorIdAsync(pBlog);
            ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
            ViewBag.Error = "";
            return View(blog);
        }


        // accion que recibe los datos modificados
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Blog pBlog)
        {
            try
            {
                int result = await blogBL.ModificarAsync(pBlog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Categorias = await categoriaBL.ObtenertodosAsync();
                return View(pBlog);
            }
        }

        // muestra pagina para confirmar la eliminacion
        public async Task<IActionResult> Delete(Blog pBlog)
        {
            ViewBag.Error = "";
            var blog = await blogBL.ObtenerPorIdAsync(pBlog);
            blog.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = pBlog.Id });
            return View();
        }

        // accion que recive la confirnmacion para eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Blog pBlog)
        {
            try
            {
                int result = await blogBL.EliminarAsync(pBlog);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var blog = await blogBL.ObtenerPorIdAsync(pBlog);
                if (blog == null)
                    blog = new Blog();

                if (blog.Id > 0)
                    blog.Categoria = await categoriaBL.obtenerPorId(new Categoria { Id = pBlog.Id });
                return View(pBlog);
            }
        }
    }
}
