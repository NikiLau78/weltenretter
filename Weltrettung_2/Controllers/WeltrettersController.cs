using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Weltrettung_2.Models;

namespace Weltrettung_2.Controllers
{
    public class WeltrettersController : Controller
    {
        private readonly Weltretter_02Context _context;

        public WeltrettersController(Weltretter_02Context context)
        {
            _context = context;
        }

        // GET: Weltretters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Weltretters.ToListAsync());
        }

        // GET: Weltretters/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weltretter = await _context.Weltretters
                .FirstOrDefaultAsync(m => m.Mail == id);
            if (weltretter == null)
            {
                return NotFound();
            }

            return View(weltretter);
        }

        // GET: Weltretters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weltretters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Country,Mail,Skill,OfAge,Fraction")] Weltretter weltretter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weltretter);
                await _context.SaveChangesAsync();
                if (weltretter.Fraction == true)
                {
                    return RedirectToAction(nameof(BadSite));
                }
                else if (weltretter.Fraction == false)
                {
                    return RedirectToAction(nameof(GoodSite));
                }
              
                return RedirectToAction(nameof(Index));
            }
                return View(weltretter);            
        }
        public ViewResult BadSite()
        {
            return View("badSite");
        }
        public ViewResult GoodSite()
        {
            return View("goodSite");
        }

        // GET: Weltretters/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weltretter = await _context.Weltretters.FindAsync(id);
            if (weltretter == null)
            {
                return NotFound();
            }
            return View(weltretter);
        }

        // POST: Weltretters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Country,Mail,Skill,OfAge,Fraction")] Weltretter weltretter)
        {
            if (id != weltretter.Mail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weltretter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeltretterExists(weltretter.Mail))
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
                return View(weltretter);
        }

        // GET: Weltretters/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weltretter = await _context.Weltretters
                .FirstOrDefaultAsync(m => m.Mail == id);
            if (weltretter == null)
            {
                return NotFound();
            }

            return View(weltretter);
        }

        // POST: Weltretters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var weltretter = await _context.Weltretters.FindAsync(id);
            _context.Weltretters.Remove(weltretter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeltretterExists(string id)
        {
            return _context.Weltretters.Any(e => e.Mail == id);
        }
    }
}
