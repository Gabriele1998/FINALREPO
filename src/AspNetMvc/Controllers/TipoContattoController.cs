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
    public class TipoContattoController : Controller
    {
        private readonly AnagraficaContext _context;

        public TipoContattoController(AnagraficaContext context)
        {
            _context = context;
        }

        // GET: TipoContatto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoContatto.ToListAsync());
        }

        // GET: TipoContatto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContatto = await _context.TipoContatto
                .FirstOrDefaultAsync(m => m.TipoContattoId == id);
            if (tipoContatto == null)
            {
                return NotFound();
            }

            return View(tipoContatto);
        }

        // GET: TipoContatto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoContatto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoContattoId,Descrizione")] TipoContatto tipoContatto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoContatto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoContatto);
        }

        // GET: TipoContatto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContatto = await _context.TipoContatto.FindAsync(id);
            if (tipoContatto == null)
            {
                return NotFound();
            }
            return View(tipoContatto);
        }

        // POST: TipoContatto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoContattoId,Descrizione")] TipoContatto tipoContatto)
        {
            if (id != tipoContatto.TipoContattoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoContatto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoContattoExists(tipoContatto.TipoContattoId))
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
            return View(tipoContatto);
        }

        // GET: TipoContatto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoContatto = await _context.TipoContatto
                .FirstOrDefaultAsync(m => m.TipoContattoId == id);
            if (tipoContatto == null)
            {
                return NotFound();
            }

            return View(tipoContatto);
        }

        // POST: TipoContatto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoContatto = await _context.TipoContatto.FindAsync(id);
            _context.TipoContatto.Remove(tipoContatto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoContattoExists(int id)
        {
            return _context.TipoContatto.Any(e => e.TipoContattoId == id);
        }
    }
}
