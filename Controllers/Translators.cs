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
    public class Translators : Controller
    {
        private readonly CeviriContext _context;

        public Translators(CeviriContext context)
        {
            _context = context;
        }

        // GET: Translators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Translators.ToListAsync());
        }

        // GET: Translators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators
                .FirstOrDefaultAsync(m => m.TranslatorID == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // GET: Translators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Translators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TranslatorID,FirstMidName,LastName")] Translator translator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(translator);
        }

        // GET: Translators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators.FindAsync(id);
            if (translator == null)
            {
                return NotFound();
            }
            return View(translator);
        }

        // POST: Translators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TranslatorID,FirstMidName,LastName")] Translator translator)
        {
            if (id != translator.TranslatorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslatorExists(translator.TranslatorID))
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
            return View(translator);
        }

        // GET: Translators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translator = await _context.Translators
                .FirstOrDefaultAsync(m => m.TranslatorID == id);
            if (translator == null)
            {
                return NotFound();
            }

            return View(translator);
        }

        // POST: Translators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var translator = await _context.Translators.FindAsync(id);
            _context.Translators.Remove(translator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslatorExists(int id)
        {
            return _context.Translators.Any(e => e.TranslatorID == id);
        }
    }
}
