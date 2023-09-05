using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using normari.Data;
using normari.Models;

namespace normari.Controllers
{
    public class TimpisController : Controller
    {
        private readonly TestContext _context;
        private Stopwatch _stopWatch;

        public TimpisController(TestContext context)
        {
            _context = context;
            _stopWatch = new Stopwatch();
        }

        // GET: Timpis
        public async Task<IActionResult> Index()
        {
            return _context.Timpis != null ?
                        View(await _context.Timpis.ToListAsync()) :
                        Problem("Entity set 'TestContext.Timpis'  is null.");
        }
        public IActionResult Start()
        {
            _stopWatch.Restart();
            return RedirectToAction("Create", "Home");
        }

        public IActionResult Stop()
        {
            _stopWatch.Stop();
            TimeSpan ts = _stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            return RedirectToAction("Create", "Home");
        }

        public IActionResult TimpiPartial()
        {
            return PartialView("_Timpi");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TimpiPartial(List<Timpi> timpi)
        {
            if (timpi != null)
            {
                _context.AddRange(timpi);
                _context.SaveChanges();
            }
                
            return PartialView("_Timpi", _context.Timpis);
        }

        // GET: Timpis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timpis == null)
            {
                return NotFound();
            }

            var timpi = await _context.Timpis
                .FirstOrDefaultAsync(m => m.Timpid == id);
            if (timpi == null)
            {
                return NotFound();
            }

            return View(timpi);
        }

        // GET: Timpis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Timpis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Timpid,Timp1,Timp2,Timp3,Timp4,Timp5,Timp6,Timp7,Timp8,Timp9,Timp10,Timp11,Timp12,Timp13,Timp14,Timp15,Timptotal,Starttime,Endtime,Normaid")] Timpi timpi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timpi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timpi);
        }

        // GET: Timpis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timpis == null)
            {
                return NotFound();
            }

            var timpi = await _context.Timpis.FindAsync(id);
            if (timpi == null)
            {
                return NotFound();
            }
            return View(timpi);
        }

        // POST: Timpis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Timpid,Timp1,Timp2,Timp3,Timp4,Timp5,Timp6,Timp7,Timp8,Timp9,Timp10,Timp11,Timp12,Timp13,Timp14,Timp15,Timptotal,Starttime,Endtime,Normaid")] Timpi timpi)
        {
            if (id != timpi.Timpid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timpi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimpiExists(timpi.Timpid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timpi);
        }

        // GET: Timpis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timpis == null)
            {
                return NotFound();
            }

            var timpi = await _context.Timpis
                .FirstOrDefaultAsync(m => m.Timpid == id);
            if (timpi == null)
            {
                return NotFound();
            }

            return View(timpi);
        }

        // POST: Timpis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timpis == null)
            {
                return Problem("Entity set 'TestContext.Timpis'  is null.");
            }
            var timpi = await _context.Timpis.FindAsync(id);
            if (timpi != null)
            {
                _context.Timpis.Remove(timpi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimpiExists(int id)
        {
            return (_context.Timpis?.Any(e => e.Timpid == id)).GetValueOrDefault();
        }
    }
}
