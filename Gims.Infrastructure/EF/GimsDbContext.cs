using Gims.Infrastructure.EF.Configurations;
using Gims.Infrastructure.EF.Configurations.Party;
using Gims.Infrastructure.EF.Configurations.Reinsurance;
using Gims.Infrastructure.EF.Configurations.Workflow;
using Microsoft.EntityFrameworkCore;

namespace Gims.Infrastructure.EF
{
    public class GimsDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Reinsurance configs
            modelBuilder.ApplyConfiguration(new ReinsurerConfiguration());
            modelBuilder.ApplyConfiguration(new TreatyConfiguration());
            modelBuilder.ApplyConfiguration(new ReinsuranceAllocationConfiguration());
            modelBuilder.ApplyConfiguration(new TreatyReinsurerConfiguration());
            
            // Existing configs
            modelBuilder.ApplyConfiguration(new PolicyConfiguration());
            modelBuilder.ApplyConfiguration(new InsureItemConfiguration());
            modelBuilder.ApplyConfiguration(new InsureItemGroupConfiguration());
            //  modelBuilder.ApplyConfiguration(new PartyAddressConfiguration());
            //  modelBuilder.ApplyConfiguration(new PartyContactConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionGroupConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionTaskConfiguration());
        }

    }
}