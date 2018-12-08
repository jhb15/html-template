using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AberFitnessLayout.Models;
using LayoutService.Models;
using Microsoft.AspNetCore.Authorization;

namespace LayoutService.Controllers
{
    [Authorize("administrator")]
    public class AppLinksManagementController : Controller
    {
        private readonly LayoutServiceContext _context;

        public AppLinksManagementController(LayoutServiceContext context)
        {
            _context = context;
        }

        // GET: AppLinks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppLink.ToListAsync());
        }

        // GET: AppLinks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appLink = await _context.AppLink
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appLink == null)
            {
                return NotFound();
            }

            return View(appLink);
        }

        // GET: AppLinks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisplayName,Uri,AccessLevel")] AppLink appLink)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appLink);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appLink);
        }

        // GET: AppLinks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appLink = await _context.AppLink.FindAsync(id);
            if (appLink == null)
            {
                return NotFound();
            }
            return View(appLink);
        }

        // POST: AppLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisplayName,Uri,AccessLevel")] AppLink appLink)
        {
            if (id != appLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appLink);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppLinkExists(appLink.Id))
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
            return View(appLink);
        }

        // GET: AppLinks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appLink = await _context.AppLink
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appLink == null)
            {
                return NotFound();
            }

            return View(appLink);
        }

        // POST: AppLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appLink = await _context.AppLink.FindAsync(id);
            _context.AppLink.Remove(appLink);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppLinkExists(int id)
        {
            return _context.AppLink.Any(e => e.Id == id);
        }
    }
}
