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
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaContext _context;

        public AnagraficaController(AnagraficaContext context)
        {
            _context = context;
        }

        // GET: Anagrafica
        public async Task<IActionResult> Index()
        {
            var anagraficaContext = _context.Anagrafica.Include(a => a.TipoAnagrafica);
            return View(await anagraficaContext.ToListAsync());
        }

        // GET: Anagrafica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica
                .Include(a => a.TipoAnagrafica)
                .FirstOrDefaultAsync(m => m.AnagraficaId == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // GET: Anagrafica/Create
        public IActionResult Create()
        {
            ViewData["TipoAnagraficaId"] = new SelectList(_context.TipoAnagrafica, "TipoAnagraficaId", "TipoAnagraficaId");
            return View();
        }

        // POST: Anagrafica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnagraficaId,CodiceAnagrafica,IsAzienda,Nome,Cognome,RagioneSociale,PartitaIva,CodiceFiscale,TipoAnagraficaId")] Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anagrafica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoAnagraficaId"] = new SelectList(_context.TipoAnagrafica, "TipoAnagraficaId", "TipoAnagraficaId", anagrafica.TipoAnagraficaId);
            return View(anagrafica);
        }

        // GET: Anagrafica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica.FindAsync(id);
            if (anagrafica == null)
            {
                return NotFound();
            }
            ViewData["TipoAnagraficaId"] = new SelectList(_context.TipoAnagrafica, "TipoAnagraficaId", "TipoAnagraficaId", anagrafica.TipoAnagraficaId);
            return View(anagrafica);
        }

        // POST: Anagrafica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnagraficaId,CodiceAnagrafica,IsAzienda,Nome,Cognome,RagioneSociale,PartitaIva,CodiceFiscale,TipoAnagraficaId")] Anagrafica anagrafica)
        {
            if (id != anagrafica.AnagraficaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anagrafica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnagraficaExists(anagrafica.AnagraficaId))
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
            ViewData["TipoAnagraficaId"] = new SelectList(_context.TipoAnagrafica, "TipoAnagraficaId", "TipoAnagraficaId", anagrafica.TipoAnagraficaId);
            return View(anagrafica);
        }

        // GET: Anagrafica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anagrafica = await _context.Anagrafica
                .Include(a => a.TipoAnagrafica)
                .FirstOrDefaultAsync(m => m.AnagraficaId == id);
            if (anagrafica == null)
            {
                return NotFound();
            }

            return View(anagrafica);
        }

        // POST: Anagrafica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anagrafica = await _context.Anagrafica.FindAsync(id);
            _context.Anagrafica.Remove(anagrafica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnagraficaExists(int id)
        {
            return _context.Anagrafica.Any(e => e.AnagraficaId == id);
        }
    }
}