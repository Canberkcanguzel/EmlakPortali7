using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmlakPortali7.Data;
using EmlakPortali7.Models;

namespace EmlakPortali7.Controllers
{
    public class EmlakModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmlakModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmlakModels
        public async Task<IActionResult> Index()
        {
              return _context.EmlakModels != null ? 
                          View(await _context.EmlakModels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EmlakModels'  is null.");
        }

        // GET: EmlakModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmlakModels == null)
            {
                return NotFound();
            }

            var emlakModels = await _context.EmlakModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emlakModels == null)
            {
                return NotFound();
            }

            return View(emlakModels);
        }

        // GET: EmlakModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmlakModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,Location,Image,OwnerId")] EmlakModels emlakModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emlakModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emlakModels);
        }

        // GET: EmlakModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmlakModels == null)
            {
                return NotFound();
            }

            var emlakModels = await _context.EmlakModels.FindAsync(id);
            if (emlakModels == null)
            {
                return NotFound();
            }
            return View(emlakModels);
        }

        // POST: EmlakModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,Location,Image,OwnerId")] EmlakModels emlakModels)
        {
            if (id != emlakModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emlakModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmlakModelsExists(emlakModels.Id))
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
            return View(emlakModels);
        }

        // GET: EmlakModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmlakModels == null)
            {
                return NotFound();
            }

            var emlakModels = await _context.EmlakModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emlakModels == null)
            {
                return NotFound();
            }

            return View(emlakModels);
        }

        // POST: EmlakModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmlakModels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmlakModels'  is null.");
            }
            var emlakModels = await _context.EmlakModels.FindAsync(id);
            if (emlakModels != null)
            {
                _context.EmlakModels.Remove(emlakModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmlakModelsExists(int id)
        {
          return (_context.EmlakModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
