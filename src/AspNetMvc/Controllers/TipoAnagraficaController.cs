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
    public class TipoAnagraficaController : Controller
    {
        private readonly AnagraficaContext _context;

        public TipoAnagraficaController(AnagraficaContext context)
        {
            _context = context;
        }

        // GET: TipoAnagrafica
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAnagrafica.ToListAsync());
        }

        // GET: TipoAnagrafica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAnagrafica = await _context.TipoAnagrafica
                .FirstOrDefaultAsync(m => m.TipoAnagraficaId == id);
            if (tipoAnagrafica == null)
            {
                return NotFound();
            }

            return View(tipoAnagrafica);
        }

        // GET: TipoAnagrafica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAnagrafica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoAnagraficaId,Descrizione")] TipoAnagrafica tipoAnagrafica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAnagrafica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAnagrafica);
        }

        // GET: TipoAnagrafica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAnagrafica = await _context.TipoAnagrafica.FindAsync(id);
            if (tipoAnagrafica == null)
            {
                return NotFound();
            }
            return View(tipoAnagrafica);
        }

        // POST: TipoAnagrafica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoAnagraficaId,Descrizione")] TipoAnagrafica tipoAnagrafica)
        {
            if (id != tipoAnagrafica.TipoAnagraficaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAnagrafica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAnagraficaExists(tipoAnagrafica.TipoAnagraficaId))
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
            return View(tipoAnagrafica);
        }

        // GET: TipoAnagrafica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAnagrafica = await _context.TipoAnagrafica
                .FirstOrDefaultAsync(m => m.TipoAnagraficaId == id);
            if (tipoAnagrafica == null)
            {
                return NotFound();
            }

            return View(tipoAnagrafica);
        }

        // POST: TipoAnagrafica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAnagrafica = await _context.TipoAnagrafica.FindAsync(id);
            _context.TipoAnagrafica.Remove(tipoAnagrafica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAnagraficaExists(int id)
        {
            return _context.TipoAnagrafica.Any(e => e.TipoAnagraficaId == id);
        }
    }
}
