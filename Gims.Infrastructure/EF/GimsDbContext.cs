using Gims.Core.Domain.Dms;
using Gims.Core.Domain.Reinsurance;
using Gims.Core.Domain.Workflow;
using Gims.Infrastructure.EF.Configurations;
using Gims.Infrastructure.EF.Configurations.Dms; // <-- add this for Document configs
using Gims.Infrastructure.EF.Configurations.Party;
using Gims.Infrastructure.EF.Configurations.Workflow;
using Microsoft.EntityFrameworkCore;

using Gims.Infrastructure.EF.Configurations.Reinsurance;

namespace Gims.Infrastructure.EF
{
    public class GimsDbContext : DbContext
    {
        public GimsDbContext(DbContextOptions<GimsDbContext> options)
            : base(options) { }

        // Document domain DbSets
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<DocumentVersion> DocumentVersions { get; set; } = null!;
        public DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public DbSet<DocumentTag> DocumentTags { get; set; } = null!;

        // Other domains (examples)
        public DbSet<Reinsurer> Reinsurers { get; set; } = null!;
        public DbSet<Treaty> Treaties { get; set; } = null!;
        public DbSet<FunctionGroup> FunctionGroups { get; set; } = null!;
        public DbSet<FunctionTask> FunctionTasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GimsDbContext).Assembly);
        }
    }
}