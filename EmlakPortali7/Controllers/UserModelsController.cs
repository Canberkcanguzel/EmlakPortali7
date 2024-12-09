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
    public class UserModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
              return _context.userModels != null ? 
                          View(await _context.userModels.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.userModels'  is null.");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.userModels == null)
            {
                return NotFound();
            }

            var userModels = await _context.userModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModels == null)
            {
                return NotFound();
            }

            return View(userModels);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,Role")] UserModels userModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModels);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.userModels == null)
            {
                return NotFound();
            }

            var userModels = await _context.userModels.FindAsync(id);
            if (userModels == null)
            {
                return NotFound();
            }
            return View(userModels);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,Role")] UserModels userModels)
        {
            if (id != userModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelsExists(userModels.Id))
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
            return View(userModels);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.userModels == null)
            {
                return NotFound();
            }

            var userModels = await _context.userModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userModels == null)
            {
                return NotFound();
            }

            return View(userModels);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.userModels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.userModels'  is null.");
            }
            var userModels = await _context.userModels.FindAsync(id);
            if (userModels != null)
            {
                _context.userModels.Remove(userModels);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelsExists(int id)
        {
          return (_context.userModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
