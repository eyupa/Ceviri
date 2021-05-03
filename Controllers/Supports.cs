using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ceviri;
using Ceviri.Data;

namespace Ceviri.Controllers
{
    public class Supports : Controller
    {
        private readonly CeviriContext _context;

        public Supports(CeviriContext context)
        {
            _context = context;
        }

        // GET: Supports
        public async Task<IActionResult> Index()
        {
            var ceviriContext = _context.Supports.Include(s => s.Supporter).Include(s => s.Translate);
            return View(await ceviriContext.ToListAsync());
        }

        // GET: Supports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support = await _context.Supports
                .Include(s => s.Supporter)
                .Include(s => s.Translate)
                .FirstOrDefaultAsync(m => m.SupportId == id);
            if (support == null)
            {
                return NotFound();
            }

            return View(support);
        }

        // GET: Supports/Create
        public IActionResult Create()
        {
            ViewData["SupporterId"] = new SelectList(_context.Supporters, "SupporterId", "SupporterId");
            ViewData["TranslateId"] = new SelectList(_context.Translates, "TranslateId", "TranslateId");
            return View();
        }

        // POST: Supports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupportId,Bounty,SupporterId,TranslateId")] Support support)
        {
            if (ModelState.IsValid)
            {
                _context.Add(support);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupporterId"] = new SelectList(_context.Supporters, "SupporterId", "SupporterId", support.SupporterId);
            ViewData["TranslateId"] = new SelectList(_context.Translates, "TranslateId", "TranslateId", support.TranslateId);
            return View(support);
        }

        // GET: Supports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support = await _context.Supports.FindAsync(id);
            if (support == null)
            {
                return NotFound();
            }
            ViewData["SupporterId"] = new SelectList(_context.Supporters, "SupporterId", "SupporterId", support.SupporterId);
            ViewData["TranslateId"] = new SelectList(_context.Translates, "TranslateId", "TranslateId", support.TranslateId);
            return View(support);
        }

        // POST: Supports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupportId,Bounty,SupporterId,TranslateId")] Support support)
        {
            if (id != support.SupportId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(support);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportExists(support.SupportId))
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
            ViewData["SupporterId"] = new SelectList(_context.Supporters, "SupporterId", "SupporterId", support.SupporterId);
            ViewData["TranslateId"] = new SelectList(_context.Translates, "TranslateId", "TranslateId", support.TranslateId);
            return View(support);
        }

        // GET: Supports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var support = await _context.Supports
                .Include(s => s.Supporter)
                .Include(s => s.Translate)
                .FirstOrDefaultAsync(m => m.SupportId == id);
            if (support == null)
            {
                return NotFound();
            }

            return View(support);
        }

        // POST: Supports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var support = await _context.Supports.FindAsync(id);
            _context.Supports.Remove(support);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportExists(int id)
        {
            return _context.Supports.Any(e => e.SupportId == id);
        }
    }
}
