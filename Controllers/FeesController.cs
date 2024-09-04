using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication04G.Data;
using WebApplication04G.Models;

namespace WebApplication04G.Controllers
{
    public class FeesController : Controller
    {
        private readonly WebApplication04GContext _context;

        public FeesController(WebApplication04GContext context)
        {
            _context = context;
        }

        // GET: Fees
        public async Task<IActionResult> Index()
        {
            var webApplication04GContext = _context.Feeses.Include(f => f.Student);
            return View(await webApplication04GContext.ToListAsync());
        }

        // GET: Fees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feeses == null)
            {
                return NotFound();
            }

            var fees = await _context.Feeses
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.id == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // GET: Fees/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "SName");
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fees fees)
        {
            
                _context.Add(fees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         
        }

        // GET: Fees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feeses == null)
            {
                return NotFound();
            }

            var fees = await _context.Feeses.FindAsync(id);
            if (fees == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "SName", fees.StudentId);
            return View(fees);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,SMonth,FAmount,SDate,StudentId")] Fees fees)
        {
            if (id != fees.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeesExists(fees.id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "SName", fees.StudentId);
            return View(fees);
        }

        // GET: Fees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feeses == null)
            {
                return NotFound();
            }

            var fees = await _context.Feeses
                .Include(f => f.Student)
                .FirstOrDefaultAsync(m => m.id == id);
            if (fees == null)
            {
                return NotFound();
            }

            return View(fees);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feeses == null)
            {
                return Problem("Entity set 'WebApplication04GContext.Feeses'  is null.");
            }
            var fees = await _context.Feeses.FindAsync(id);
            if (fees != null)
            {
                _context.Feeses.Remove(fees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeesExists(int id)
        {
          return (_context.Feeses?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
