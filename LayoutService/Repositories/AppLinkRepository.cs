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
            return await context.AppLink.ToListAsync();
        }

        public async Task<List<AppLink>> GetAllWithSubLinksAsync()
        {
            return await context.AppLink.Include("SubLinks").ToListAsync();
        }

        public async Task<AppLink> GetByIdAsync(int id)
        {
            return await context.AppLink.Include("SubLinks").FirstOrDefaultAsync(al => al.Id == id);
        }

        public async Task<AppLink> UpdateAsync(AppLink appLink)
        {
            context.Update(appLink);
            await context.SaveChangesAsync();
            return appLink;
        }
    }
}
