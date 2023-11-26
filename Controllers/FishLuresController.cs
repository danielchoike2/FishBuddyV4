using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishBuddy.Models;

namespace FishBuddy.Controllers
{
    public class FishLuresController : Controller
    {
        private readonly FishContext _context;

        public FishLuresController(FishContext context)
        {
            _context = context;
        }

        // GET: FishLures
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.FishLure.Include(f => f.FishSpecies);
            return View(await fishContext.ToListAsync());
        }

        // GET: FishLures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FishLure == null)
            {
                return NotFound();
            }

            var fishLure = await _context.FishLure
                .Include(f => f.FishSpecies)
                .FirstOrDefaultAsync(m => m.FishLureId == id);
            if (fishLure == null)
            {
                return NotFound();
            }

            return View(fishLure);
        }

        // GET: FishLures/Create
        public IActionResult Create()
        {
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId");
            return View();
        }

        // POST: FishLures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishLureId,FishSpeciesId,FishLureName")] FishLure fishLure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishLure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishLure.FishSpeciesId);
            return View(fishLure);
        }

        // GET: FishLures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FishLure == null)
            {
                return NotFound();
            }

            var fishLure = await _context.FishLure.FindAsync(id);
            if (fishLure == null)
            {
                return NotFound();
            }
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishLure.FishSpeciesId);
            return View(fishLure);
        }

        // POST: FishLures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishLureId,FishSpeciesId,FishLureName")] FishLure fishLure)
        {
            if (id != fishLure.FishLureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishLure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishLureExists(fishLure.FishLureId))
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
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishLure.FishSpeciesId);
            return View(fishLure);
        }

        // GET: FishLures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FishLure == null)
            {
                return NotFound();
            }

            var fishLure = await _context.FishLure
                .Include(f => f.FishSpecies)
                .FirstOrDefaultAsync(m => m.FishLureId == id);
            if (fishLure == null)
            {
                return NotFound();
            }

            return View(fishLure);
        }

        // POST: FishLures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FishLure == null)
            {
                return Problem("Entity set 'FishContext.FishLure'  is null.");
            }
            var fishLure = await _context.FishLure.FindAsync(id);
            if (fishLure != null)
            {
                _context.FishLure.Remove(fishLure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishLureExists(int id)
        {
          return (_context.FishLure?.Any(e => e.FishLureId == id)).GetValueOrDefault();
        }
    }
}
