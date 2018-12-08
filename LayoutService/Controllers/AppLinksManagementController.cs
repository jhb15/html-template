using AberFitnessLayout.Models;
using LayoutService.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LayoutService.Controllers
{
    [Authorize("administrator")]
    public class AppLinksManagementController : Controller
    {
        private readonly IAppLinkRepository appLinkRepository;

        public AppLinksManagementController(IAppLinkRepository appLinkRepository)
        {
            this.appLinkRepository = appLinkRepository;
        }

        // GET: AppLinks
        public async Task<IActionResult> Index()
        {
            return View(await appLinkRepository.GetAllAsync());
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
                await appLinkRepository.AddAsync(appLink);
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

            var appLink = await appLinkRepository.GetByIdAsync(id.Value);
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
                await appLinkRepository.UpdateAsync(appLink);
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

            var appLink = await appLinkRepository.GetByIdAsync(id.Value);
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
            var appLink = await appLinkRepository.GetByIdAsync(id);
            await appLinkRepository.DeleteAsync(appLink);
            return RedirectToAction(nameof(Index));
        }
    }
}
