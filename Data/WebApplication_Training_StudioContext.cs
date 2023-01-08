using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication_Training_Studio.Models;

namespace WebApplication_Training_Studio.Data
{
    public class WebApplication_Training_StudioContext : DbContext
    {
        public WebApplication_Training_StudioContext (DbContextOptions<WebApplication_Training_StudioContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication_Training_Studio.Models.FitnessClass> FitnessClass { get; set; } = default!;

        public DbSet<WebApplication_Training_Studio.Models.Trainer> Trainer { get; set; }

        public DbSet<WebApplication_Training_Studio.Models.Location> Locations { get; set; }

        public DbSet<WebApplication_Training_Studio.Models.Category> Category { get; set; }

        public DbSet<WebApplication_Training_Studio.Models.Member> Member { get; set; }

        public DbSet<WebApplication_Training_Studio.Models.Subscription> Subscription { get; set; }
    }
}
