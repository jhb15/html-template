using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AberFitnessLayout.Models;

namespace LayoutService.Models
{
    public class LayoutServiceContext : DbContext
    {
        public LayoutServiceContext (DbContextOptions<LayoutServiceContext> options)
            : base(options)
        {
        }

        public DbSet<AberFitnessLayout.Models.AppLink> AppLink { get; set; }
    }
}
