using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Tabelle;

namespace AspNetMvc.Controllers
{
    public class IndirizziController : Controller
    {
        private readonly AnagraficaContext _context;

        public IndirizziController(AnagraficaContext context)
        {
            _context = context;
        }

        // GET: Indirizzi
        public async Task<IActionResult> Index()
        {
            var anagraficaContext = _context.Indirizzi.Include(i => i.Anagrafica).Include(i => i.TipoIndirizzo);
            return View(await anagraficaContext.ToListAsync());
        }

        // GET: Indirizzi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirizzi = await _context.Indirizzi
                .Include(i => i.Anagrafica)
                .Include(i => i.TipoIndirizzo)
                .FirstOrDefaultAsync(m => m.IndirizziId == id);
            if (indirizzi == null)
            {
                return NotFound();
            }

            return View(indirizzi);
        }

        // GET: Indirizzi/Create
        public IActionResult Create()
        {
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId");
            ViewData["TipoIndirizzoId"] = new SelectList(_context.TipoIndirizzo, "TipoIndirizzoId", "TipoIndirizzoId");
            return View();
        }

        // POST: Indirizzi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IndirizziId,Nazione,Regione,Provincia,Citta,Denominazione,Cap,Numero,AnagraficaId,TipoIndirizzoId")] Indirizzi indirizzi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(indirizzi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId", indirizzi.AnagraficaId);
            ViewData["TipoIndirizzoId"] = new SelectList(_context.TipoIndirizzo, "TipoIndirizzoId", "TipoIndirizzoId", indirizzi.TipoIndirizzoId);
            return View(indirizzi);
        }

        // GET: Indirizzi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirizzi = await _context.Indirizzi.FindAsync(id);
            if (indirizzi == null)
            {
                return NotFound();
            }
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId", indirizzi.AnagraficaId);
            ViewData["TipoIndirizzoId"] = new SelectList(_context.TipoIndirizzo, "TipoIndirizzoId", "TipoIndirizzoId", indirizzi.TipoIndirizzoId);
            return View(indirizzi);
        }

        // POST: Indirizzi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IndirizziId,Nazione,Regione,Provincia,Citta,Denominazione,Cap,Numero,AnagraficaId,TipoIndirizzoId")] Indirizzi indirizzi)
        {
            if (id != indirizzi.IndirizziId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(indirizzi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndirizziExists(indirizzi.IndirizziId))
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
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId", indirizzi.AnagraficaId);
            ViewData["TipoIndirizzoId"] = new SelectList(_context.TipoIndirizzo, "TipoIndirizzoId", "TipoIndirizzoId", indirizzi.TipoIndirizzoId);
            return View(indirizzi);
        }

        // GET: Indirizzi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var indirizzi = await _context.Indirizzi
                .Include(i => i.Anagrafica)
                .Include(i => i.TipoIndirizzo)
                .FirstOrDefaultAsync(m => m.IndirizziId == id);
            if (indirizzi == null)
            {
                return NotFound();
            }

            return View(indirizzi);
        }

        // POST: Indirizzi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var indirizzi = await _context.Indirizzi.FindAsync(id);
            _context.Indirizzi.Remove(indirizzi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndirizziExists(int id)
        {
            return _context.Indirizzi.Any(e => e.IndirizziId == id);
        }
    }
}
