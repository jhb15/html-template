using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LayoutService.Models;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.Repositories
{
    public class AppLinkRepository : IAppLinkRepository
    {
        private readonly LayoutServiceContext context;

        public AppLinkRepository(LayoutServiceContext ctx)
        {
            context = ctx;
        }

        public async Task<AppLink> AddAsync(AppLink appLink)
        {
            context.Add(appLink);
            await context.SaveChangesAsync();
            return appLink;
        }

        public async Task<AppLink> DeleteAsync(AppLink appLink)
        {
            context.AppLink.Remove(appLink);
            await context.SaveChangesAsync();
            return appLink;
        }

        public async Task<List<AppLink>> GetAllAsync()
        {
            return await context.AppLink.OrderBy(al => al.Priority).ToListAsync();
        }

        public async Task<List<AppLink>> GetAllWithSubLinksAsync()
        {
            var appLinks = await context.AppLink.Include("SubLinks").OrderBy(al => al.Priority).ToListAsync();
            foreach(var appLink in appLinks)
            {
                appLink.SubLinks = appLink.SubLinks.OrderBy(sl => sl.Priority).ToList();
            }
            return appLinks;
        }

        public async Task<AppLink> GetByIdAsync(int id)
        {
            var appLink = await context.AppLink.Include("SubLinks").FirstOrDefaultAsync(al => al.Id == id);
            appLink.SubLinks = appLink.SubLinks.OrderBy(sl => sl.Priority).ToList();
            return appLink;
        }

        public async Task<AppLink> UpdateAsync(AppLink appLink)
        {
            context.Update(appLink);
            await context.SaveChangesAsync();
            return appLink;
        }
    }
}
