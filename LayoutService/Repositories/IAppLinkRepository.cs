﻿using LayoutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutService.Repositories
{
    public interface IAppLinkRepository
    {
        Task<AppLink> GetByIdAsync(int id);

        Task<List<AppLink>> GetAllAsync();

        Task<List<AppLink>> GetAllWithSubLinksAsync();

        Task<AppLink> AddAsync(AppLink appLink);

        Task<AppLink> UpdateAsync(AppLink appLink);

        Task<AppLink> DeleteAsync(AppLink appLink);
    }
}
