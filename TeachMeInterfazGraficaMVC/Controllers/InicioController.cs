using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachMeEntidadesDeNegocio;
using TeachMeLogicaDeNegocio;

namespace TeachMeInterfazGraficaMVC.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class InicioController : Controller
    {
        CursoBL cursoBL = new CursoBL();
        public  async Task  <IActionResult> Index(Curso pCurso=null)
        {

            var curso = await cursoBL.ObtenerTodosAsync();
            
            return View(curso);
        }

        // GET: InicioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InicioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InicioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InicioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InicioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InicioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
