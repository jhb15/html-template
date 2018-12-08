using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AberFitnessLayout.Models;
using LayoutService.Models;
using Microsoft.EntityFrameworkCore;

namespace LayoutService.Repositories
{
    public class AppSubLinkRepository : IAppSubLinkRepository
    {
        private readonly LayoutServiceContext context;

        public AppSubLinkRepository(LayoutServiceContext ctx)
        {
            context = ctx;
        }

        public async Task<AppSubLink> AddAsync(AppSubLink appSubLink)
        {
            context.Add(appSubLink);
            await context.SaveChangesAsync();
            return appSubLink;
        }

        public async Task<AppSubLink> DeleteAsync(AppSubLink appSubLink)
        {
            context.AppSubLink.Remove(appSubLink);
            await context.SaveChangesAsync();
            return appSubLink;
        }

        public async Task<List<AppSubLink>> GetAllAsync()
        {
            return await context.AppSubLink.ToListAsync();
        }

        public async Task<AppSubLink> GetByIdAsync(int id)
        {
            return await context.AppSubLink.FirstOrDefaultAsync(al => al.Id == id);
        }

        public async Task<AppSubLink> UpdateAsync(AppSubLink appSubLink)
        {
            context.Update(appSubLink);
            await context.SaveChangesAsync();
            return appSubLink;
        }
    }
}
