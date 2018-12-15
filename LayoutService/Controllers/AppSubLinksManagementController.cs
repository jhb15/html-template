using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LayoutService.Models;
using LayoutService.Repositories;

namespace LayoutService.Controllers
{
    public class AppSubLinksManagementController : Controller
    {
        private readonly IAppSubLinkRepository appSubLinkRepository;

        public AppSubLinksManagementController(IAppSubLinkRepository appSubLinkRepository)
        {
            this.appSubLinkRepository = appSubLinkRepository;
        }

        // POST: AppSubLinksManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IconName,DisplayName,Uri,AccessLevel,AppLinkId,Priority")] AppSubLink appSubLink)
        {
            if (ModelState.IsValid)
            {
                await appSubLinkRepository.AddAsync(appSubLink);
                return RedirectToAction(nameof(AppLinksManagementController.Edit), "AppLinksManagement", new { Id = appSubLink.AppLinkId });
            }
            return View(appSubLink);
        }

        // GET: AppSubLinksManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appSubLink = await appSubLinkRepository.GetByIdAsync(id.Value);
            if (appSubLink == null)
            {
                return NotFound();
            }
            return View(appSubLink);
        }

        // POST: AppSubLinksManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IconName,DisplayName,Uri,AccessLevel,AppLinkId,Priority")] AppSubLink appSubLink)
        {
            if (id != appSubLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await appSubLinkRepository.UpdateAsync(appSubLink);
                return RedirectToAction(nameof(AppLinksManagementController.Edit), "AppLinksManagement", new { Id = appSubLink.AppLinkId });
            }
            return View(appSubLink);
        }

        // GET: AppSubLinksManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appSubLink = await appSubLinkRepository.GetByIdAsync(id.Value);
            if (appSubLink == null)
            {
                return NotFound();
            }

            return View(appSubLink);
        }

        // POST: AppSubLinksManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appSubLink = await appSubLinkRepository.GetByIdAsync(id);
            await appSubLinkRepository.DeleteAsync(appSubLink);
            return RedirectToAction(nameof(AppLinksManagementController.Edit), "AppLinksManagement", new { Id = appSubLink.AppLinkId });
        }
    }
}
