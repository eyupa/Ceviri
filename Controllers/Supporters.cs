using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ceviri.Data;
using Ceviri.Models;

namespace Ceviri.Controllers
{
    public class Supporters : Controller
    {
        private readonly CeviriContext _context;

        public Supporters(CeviriContext context)
        {
            _context = context;
        }

        // GET: Supporters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supporters.ToListAsync());
        }

        // GET: Supporters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supporter = await _context.Supporters
                .FirstOrDefaultAsync(m => m.SupporterId == id);
            if (supporter == null)
            {
                return NotFound();
            }

            return View(supporter);
        }

        // GET: Supporters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supporters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupporterId,FirstMidName,LastName")] Supporter supporter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supporter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supporter);
        }

        // GET: Supporters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supporter = await _context.Supporters.FindAsync(id);
            if (supporter == null)
            {
                return NotFound();
            }
            return View(supporter);
        }

        // POST: Supporters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupporterId,FirstMidName,LastName")] Supporter supporter)
        {
            if (id != supporter.SupporterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supporter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupporterExists(supporter.SupporterId))
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
            return View(supporter);
        }

        // GET: Supporters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supporter = await _context.Supporters
                .FirstOrDefaultAsync(m => m.SupporterId == id);
            if (supporter == null)
            {
                return NotFound();
            }

            return View(supporter);
        }

        // POST: Supporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supporter = await _context.Supporters.FindAsync(id);
            _context.Supporters.Remove(supporter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupporterExists(int id)
        {
            return _context.Supporters.Any(e => e.SupporterId == id);
        }
    }
}
