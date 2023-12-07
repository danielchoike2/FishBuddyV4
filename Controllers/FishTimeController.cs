using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishBuddy.Models;
using Microsoft.AspNetCore.Authorization;

namespace FishBuddy.Controllers
{
    [Authorize]
    public class FishTimeController : Controller
    {
        private readonly FishContext _context;

        public FishTimeController(FishContext context)
        {
            _context = context;
        }

        // GET: FishTime
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.FishTime.Include(f => f.FishSpecies);
            return View(await fishContext.ToListAsync());
        }

        // GET: FishTime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FishTime == null)
            {
                return NotFound();
            }

            var fishTime = await _context.FishTime
                .Include(f => f.FishSpecies)
                .FirstOrDefaultAsync(m => m.FishTimeId == id);
            if (fishTime == null)
            {
                return NotFound();
            }

            return View(fishTime);
        }

        // GET: FishTime/Create
        public IActionResult Create()
        {
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId");
            return View();
        }

        // POST: FishTime/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishTimeId,FishSpeciesId,BestTimes")] FishTime fishTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishTime.FishSpeciesId);
            return View(fishTime);
        }

        // GET: FishTime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FishTime == null)
            {
                return NotFound();
            }

            var fishTime = await _context.FishTime.FindAsync(id);
            if (fishTime == null)
            {
                return NotFound();
            }
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishTime.FishSpeciesId);
            return View(fishTime);
        }

        // POST: FishTime/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishTimeId,FishSpeciesId,BestTimes")] FishTime fishTime)
        {
            if (id != fishTime.FishTimeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishTimeExists(fishTime.FishTimeId))
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
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishTime.FishSpeciesId);
            return View(fishTime);
        }

        // GET: FishTime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FishTime == null)
            {
                return NotFound();
            }

            var fishTime = await _context.FishTime
                .Include(f => f.FishSpecies)
                .FirstOrDefaultAsync(m => m.FishTimeId == id);
            if (fishTime == null)
            {
                return NotFound();
            }

            return View(fishTime);
        }

        // POST: FishTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FishTime == null)
            {
                return Problem("Entity set 'FishContext.FishTime'  is null.");
            }
            var fishTime = await _context.FishTime.FindAsync(id);
            if (fishTime != null)
            {
                _context.FishTime.Remove(fishTime);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishTimeExists(int id)
        {
          return (_context.FishTime?.Any(e => e.FishTimeId == id)).GetValueOrDefault();
        }
    }
}
