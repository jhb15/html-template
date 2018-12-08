using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LayoutService.Models;

namespace LayoutService.Models
{
    public class LayoutServiceContext : DbContext
    {
        public LayoutServiceContext (DbContextOptions<LayoutServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AppLink> AppLink { get; set; }

        public DbSet<AppSubLink> AppSubLink { get; set; }
    }
}
