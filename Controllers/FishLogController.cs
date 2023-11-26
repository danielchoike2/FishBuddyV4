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
    public class FishLogController : Controller
    {
        private readonly FishContext _context;

        public FishLogController(FishContext context)
        {
            _context = context;
        }

        // GET: FishSpecies
        public async Task<IActionResult> Index()
        {
              return _context.FishList != null ? 
                          View(await _context.FishList.ToListAsync()) :
                          Problem("Entity set 'FishContext.FishList'  is null.");
        }

        // GET: FishSpecies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FishList == null)
            {
                return NotFound();
            }

            var fishSpecies = await _context.FishList
                .FirstOrDefaultAsync(m => m.ID == id);
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
        public async Task<IActionResult> Create([Bind("ID,Date,FishName,Location,MaxLength,MaxWeight")] FishLog fishSpecies)
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
            if (id == null || _context.FishList == null)
            {
                return NotFound();
            }

            var fishSpecies = await _context.FishList.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,FishName,Location,MaxLength,MaxWeight")] FishLog fishSpecies)
        {
            if (id != fishSpecies.ID)
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
                    if (!FishSpeciesExists(fishSpecies.ID))
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
            if (id == null || _context.FishList == null)
            {
                return NotFound();
            }

            var fishSpecies = await _context.FishList
                .FirstOrDefaultAsync(m => m.ID == id);
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
            if (_context.FishList == null)
            {
                return Problem("Entity set 'FishContext.FishList'  is null.");
            }
            var fishSpecies = await _context.FishList.FindAsync(id);
            if (fishSpecies != null)
            {
                _context.FishList.Remove(fishSpecies);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishSpeciesExists(int id)
        {
          return (_context.FishList?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
