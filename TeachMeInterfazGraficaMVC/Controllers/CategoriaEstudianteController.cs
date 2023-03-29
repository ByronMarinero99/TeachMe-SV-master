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
    public class CategoriaEstudianteController : Controller
    {
        CategoriaBL categoriaBL = new CategoriaBL();

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


    }
}
