using AberFitnessLayout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutService.Repositories
{
    public interface IAppSubLinkRepository
    {
        Task<AppSubLink> GetByIdAsync(int id);

        Task<List<AppSubLink>> GetAllAsync();

        Task<AppSubLink> AddAsync(AppSubLink appLink);

        Task<AppSubLink> UpdateAsync(AppSubLink appLink);

        Task<AppSubLink> DeleteAsync(AppSubLink appLink);
    }
}
