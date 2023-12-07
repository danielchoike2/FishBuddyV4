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
    public class FishWeatherController : Controller
    {
        private readonly FishContext _context;

        public FishWeatherController(FishContext context)
        {
            _context = context;
        }

        // GET: FishWeather
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var fishContext = _context.FishWeather.Include(f => f.FishSpecies);
            return View(await fishContext.ToListAsync());
        }

        // GET: FishWeather/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FishWeather == null)
            {
                return NotFound();
            }

            var fishWeather = await _context.FishWeather
                .Include(f => f.FishSpecies)
                .FirstOrDefaultAsync(m => m.FishWeatherId == id);
            if (fishWeather == null)
            {
                return NotFound();
            }

            return View(fishWeather);
        }

        // GET: FishWeather/Create
        public IActionResult Create()
        {
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId");
            return View();
        }

        // POST: FishWeather/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishWeatherId,FishSpeciesId,BestWeathers")] FishWeather fishWeather)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishWeather);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishWeather.FishSpeciesId);
            return View(fishWeather);
        }

        // GET: FishWeather/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FishWeather == null)
            {
                return NotFound();
            }

            var fishWeather = await _context.FishWeather.FindAsync(id);
            if (fishWeather == null)
            {
                return NotFound();
            }
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishWeather.FishSpeciesId);
            return View(fishWeather);
        }

        // POST: FishWeather/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishWeatherId,FishSpeciesId,BestWeathers")] FishWeather fishWeather)
        {
            if (id != fishWeather.FishWeatherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishWeather);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishWeatherExists(fishWeather.FishWeatherId))
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
            ViewData["FishSpeciesId"] = new SelectList(_context.FishSpecies, "FishSpeciesId", "FishSpeciesId", fishWeather.FishSpeciesId);
            return View(fishWeather);
        }

        // GET: FishWeather/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FishWeather == null)
            {
                return NotFound();
            }

            var fishWeather = await _context.FishWeather
                .Include(f => f.FishSpecies)
                .FirstOrDefaultAsync(m => m.FishWeatherId == id);
            if (fishWeather == null)
            {
                return NotFound();
            }

            return View(fishWeather);
        }

        // POST: FishWeather/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FishWeather == null)
            {
                return Problem("Entity set 'FishContext.FishWeather'  is null.");
            }
            var fishWeather = await _context.FishWeather.FindAsync(id);
            if (fishWeather != null)
            {
                _context.FishWeather.Remove(fishWeather);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishWeatherExists(int id)
        {
          return (_context.FishWeather?.Any(e => e.FishWeatherId == id)).GetValueOrDefault();
        }
    }
}
