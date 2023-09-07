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
        private StopWatchModel _stopwatch;

        public TimpisController(TestContext context)
        {
            _context = context;
            _stopwatch = new StopWatchModel();
        }

        // GET: Timpis
        public async Task<IActionResult> Index()
        {
            return _context.Timpis != null ?
                        View(await _context.Timpis.ToListAsync()) :
                        Problem("Entity set 'TestContext.Timpis'  is null.");
        }


        [HttpPost]
        [IgnoreAntiforgeryToken]

        public IActionResult Send([FromBody] List<List<int>> json)
        {
            //if (!ModelState.IsValid)
            //    return NotFound();
            Timpi[] list = new Timpi[json[0].Count];
            
            for (var i = 0; i < json[0].Count; i++)
            {
                var total = 0;
                var totalTimeMili = 0;
                for(var j = 0;j < 15; j++)
                {
                    if (json[j][i] != null)
                    {
                        total++;
                        totalTimeMili += json[j][i];
                    }
                }
                var totalTime = TimeSpan.FromMilliseconds(totalTimeMili);
                var endTime = DateTime.Now;
                //var startTime = endTime - totalTime;

                list[i] = new Timpi
                {
                    Timp1 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[0][i])),
                    Timp2 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[1][i])),
                    Timp3 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[2][i])),
                    Timp4 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[3][i])),
                    Timp5 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[4][i])),
                    Timp6 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[5][i])),
                    Timp7 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[6][i])),
                    Timp8 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[7][i])),
                    Timp9 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[8][i])),
                    Timp10 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[9][i])),
                    Timp11 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[10][i])),
                    Timp12 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[11][i])),
                    Timp13 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[12][i])),
                    Timp14 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[13][i])),
                    Timp15 = TimeOnly.FromTimeSpan(TimeSpan.FromMilliseconds(json[14][i])),
                    Timptotal = TimeOnly.FromTimeSpan(totalTime),
                    Endtime = endTime,
                    //Starttime = startTime,
                    Normaid = json[15][0]
                };
            }

            _context.Timpis.AddRange(list);
            //_context.Timpis.Add(t);
            _context.SaveChanges();
            return Ok(json);
            
        }

        public IActionResult Send()
        {

            return RedirectToAction("Index");
        }

        public IActionResult Stopwatch(int? op, int? id)
        {
            if (op == null)
                op = 1;
            ViewBag.nid = id;
            ViewBag.op = op;
            return View();
        }
        


        public IActionResult TimpiPartial()
        {
            ViewBag.stopwatch = _stopwatch;
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
