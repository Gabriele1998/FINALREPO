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
    public class ContattiController : Controller
    {
        private readonly AnagraficaContext _context;

        public ContattiController(AnagraficaContext context)
        {
            _context = context;
        }

        // GET: Contatti
        public async Task<IActionResult> Index()
        {
            var anagraficaContext = _context.Contatti.Include(c => c.Anagrafica).Include(c => c.TipoContatto);
            return View(await anagraficaContext.ToListAsync());
        }

        // GET: Contatti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatti = await _context.Contatti
                .Include(c => c.Anagrafica)
                .Include(c => c.TipoContatto)
                .FirstOrDefaultAsync(m => m.ContattiId == id);
            if (contatti == null)
            {
                return NotFound();
            }

            return View(contatti);
        }

        // GET: Contatti/Create
        public IActionResult Create()
        {
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId");
            ViewData["TipoContattoId"] = new SelectList(_context.TipoContatto, "TipoContattoId", "TipoContattoId");
            return View();
        }

        // POST: Contatti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContattiId,Valore,Note,AnagraficaId,TipoContattoId")] Contatti contatti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId", contatti.AnagraficaId);
            ViewData["TipoContattoId"] = new SelectList(_context.TipoContatto, "TipoContattoId", "TipoContattoId", contatti.TipoContattoId);
            return View(contatti);
        }

        // GET: Contatti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatti = await _context.Contatti.FindAsync(id);
            if (contatti == null)
            {
                return NotFound();
            }
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId", contatti.AnagraficaId);
            ViewData["TipoContattoId"] = new SelectList(_context.TipoContatto, "TipoContattoId", "TipoContattoId", contatti.TipoContattoId);
            return View(contatti);
        }

        // POST: Contatti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContattiId,Valore,Note,AnagraficaId,TipoContattoId")] Contatti contatti)
        {
            if (id != contatti.ContattiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContattiExists(contatti.ContattiId))
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
            ViewData["AnagraficaId"] = new SelectList(_context.Anagrafica, "AnagraficaId", "AnagraficaId", contatti.AnagraficaId);
            ViewData["TipoContattoId"] = new SelectList(_context.TipoContatto, "TipoContattoId", "TipoContattoId", contatti.TipoContattoId);
            return View(contatti);
        }

        // GET: Contatti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatti = await _context.Contatti
                .Include(c => c.Anagrafica)
                .Include(c => c.TipoContatto)
                .FirstOrDefaultAsync(m => m.ContattiId == id);
            if (contatti == null)
            {
                return NotFound();
            }

            return View(contatti);
        }

        // POST: Contatti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contatti = await _context.Contatti.FindAsync(id);
            _context.Contatti.Remove(contatti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContattiExists(int id)
        {
            return _context.Contatti.Any(e => e.ContattiId == id);
        }
    }
}
