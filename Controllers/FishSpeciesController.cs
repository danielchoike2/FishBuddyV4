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
    public class FishSpeciesController : Controller
    {
        private readonly FishContext _context;

        public FishSpeciesController(FishContext context)
        {
            _context = context;
        }

        // GET: FishSpecies
        public async Task<IActionResult> Index()
        {
              return _context.FishSpecies != null ? 
                          View(await _context.FishSpecies.ToListAsync()) :
                          Problem("Entity set 'FishContext.FishSpecies'  is null.");
        }

        // GET: FishSpecies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FishSpecies == null)
            {
                return NotFound();
            }

            var fishSpecies = await _context.FishSpecies
                .FirstOrDefaultAsync(m => m.FishSpeciesId == id);
            if (fishSpecies == null)
            {
                return NotFound();
            }

            return View(fishSpecies);
        }

        // GET: FishSpecies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FishSpecies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishSpeciesId,FishCommonName,FishSpeciesName,FishHabitat,RecordWeight,RecordLength")] FishSpecies fishSpecies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishSpecies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishSpecies);
        }

        // GET: FishSpecies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FishSpecies == null)
            {
                return NotFound();
            }

            var fishSpecies = await _context.FishSpecies.FindAsync(id);
            if (fishSpecies == null)
            {
                return NotFound();
            }
            return View(fishSpecies);
        }

        // POST: FishSpecies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishSpeciesId,FishCommonName,FishSpeciesName,FishHabitat,RecordWeight,RecordLength")] FishSpecies fishSpecies)
        {
            if (id != fishSpecies.FishSpeciesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishSpecies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishSpeciesExists(fishSpecies.FishSpeciesId))
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
            return View(fishSpecies);
        }

        // GET: FishSpecies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FishSpecies == null)
            {
                return NotFound();
            }

            var fishSpecies = await _context.FishSpecies
                .FirstOrDefaultAsync(m => m.FishSpeciesId == id);
            if (fishSpecies == null)
            {
                return NotFound();
            }

            return View(fishSpecies);
        }

        // POST: FishSpecies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FishSpecies == null)
            {
                return Problem("Entity set 'FishContext.FishSpecies'  is null.");
            }
            var fishSpecies = await _context.FishSpecies.FindAsync(id);
            if (fishSpecies != null)
            {
                _context.FishSpecies.Remove(fishSpecies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishSpeciesExists(int id)
        {
          return (_context.FishSpecies?.Any(e => e.FishSpeciesId == id)).GetValueOrDefault();
        }
    }
}
