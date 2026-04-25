using Gims.Core.SysMan.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Gims.Infrastructure.EF
{
    public class GimsDbContext
    : IdentityDbContext<GimsUser, GimsUserRole, string>
    {
        public GimsDbContext(DbContextOptions<GimsDbContext> options)
            : base(options)
        {
        }

        public DbSet<GimsModule> Modules { get; set; }
        public DbSet<GimsRoleModule> RoleModules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GimsModuleConfiguration());
            modelBuilder.ApplyConfiguration(new GimsRoleModuleConfiguration());
        }
    }
}
