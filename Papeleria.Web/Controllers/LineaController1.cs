using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Web.Controllers
{
    public class LineaController1 : Controller
    {
        // GET: LineaController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: LineaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LineaController1/Create
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

        // GET: LineaController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineaController1/Edit/5
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

        // GET: LineaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineaController1/Delete/5
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
