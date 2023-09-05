using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using normari.Data;
using normari.Models;
using System.Diagnostics;

namespace normari.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly TestContext m_db;

        public HomeController(TestContext db)
        {
            m_db = db;
        }

        public IActionResult Index()
        {
            ViewData["Sectii"] = m_db.Sectiis;
            ViewData["Operatietip"] = m_db.Operatietips;
            ViewData["Operatiestandard"] = m_db.Operatiestandards;
            ViewData["Postlucru"] = m_db.Postlucrus;
            return View();
        }

        public IActionResult Details(int id)
        {
            Norme obj=m_db.Normes.Find(id);
            return View(obj);
        }
        public IActionResult Norme()
        {
            IEnumerable<Norme> obj = m_db.Normes;
            ViewBag.Sectie = m_db.Sectiis;
            ViewBag.Operatietip = m_db.Operatietips;
            ViewBag.Operatiestandard = m_db.Operatiestandards;
            ViewBag.Postlucru = m_db.Postlucrus;
            return View(obj);
        }

        public ActionResult Create()
        {
            ViewBag.Sectie = new SelectList(m_db.Sectiis, "Sectieid", "Sectie");
            ViewBag.Operatietip = new SelectList(m_db.Operatietips,"Operatietipid", "Operatietip1");
            ViewBag.Operatiestandard = new SelectList(m_db.Operatiestandards, "Operatiestadnardid", "Operatiestandard1");
            ViewBag.Postlucru = new SelectList(m_db.Postlucrus, "Postid", "Postdelucru");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Norme obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.Operatiemultipla = !obj.Operatiesimpla;
            try
            {

                m_db.Normes.Add(obj);
                m_db.SaveChanges();
                return RedirectToAction("Norme");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}