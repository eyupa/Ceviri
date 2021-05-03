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
    public class TranslateController : Controller
    {
        private readonly CeviriContext _context;

        public TranslateController(CeviriContext context)
        {
            _context = context;
        }

        // GET: Translate
        public async Task<IActionResult> Index()
        {
            var ceviriContext = _context.Translates.Include(t => t.Book).Include(t => t.Translator);
            return View(await ceviriContext.ToListAsync());
        }

        // GET: Translate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translate = await _context.Translates
                .Include(t => t.Book)
                .Include(t => t.Translator)
                .FirstOrDefaultAsync(m => m.TranslateId == id);
            if (translate == null)
            {
                return NotFound();
            }

            return View(translate);
        }

        // GET: Translate/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            ViewData["TranslatorId"] = new SelectList(_context.Translators, "TranslatorID", "TranslatorID");
            return View();
        }

        // POST: Translate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TranslateId,BookId,TranslatorId")] Translate translate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", translate.BookId);
            ViewData["TranslatorId"] = new SelectList(_context.Translators, "TranslatorID", "TranslatorID", translate.TranslatorId);
            return View(translate);
        }

        // GET: Translate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translate = await _context.Translates.FindAsync(id);
            if (translate == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", translate.BookId);
            ViewData["TranslatorId"] = new SelectList(_context.Translators, "TranslatorID", "TranslatorID", translate.TranslatorId);
            return View(translate);
        }

        // POST: Translate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TranslateId,BookId,TranslatorId")] Translate translate)
        {
            if (id != translate.TranslateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslateExists(translate.TranslateId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", translate.BookId);
            ViewData["TranslatorId"] = new SelectList(_context.Translators, "TranslatorID", "TranslatorID", translate.TranslatorId);
            return View(translate);
        }

        // GET: Translate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translate = await _context.Translates
                .Include(t => t.Book)
                .Include(t => t.Translator)
                .FirstOrDefaultAsync(m => m.TranslateId == id);
            if (translate == null)
            {
                return NotFound();
            }

            return View(translate);
        }

        // POST: Translate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var translate = await _context.Translates.FindAsync(id);
            _context.Translates.Remove(translate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslateExists(int id)
        {
            return _context.Translates.Any(e => e.TranslateId == id);
        }
    }
}
