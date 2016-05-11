using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using zhsqw.Models;

namespace zhsqw.Models
{
    public class DbContext : IdentityDbContext<IdentityUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<news> news { get; set; }
        public DbSet<w_areas> w_areas { get; set; }
    }
}
