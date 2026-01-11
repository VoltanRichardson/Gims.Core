using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gims.Infrastructure.EF
{
    public class GimsDbContextFactory : IDesignTimeDbContextFactory<GimsDbContext>
    {
        public GimsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GimsDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=GimsDb;Trusted_Connection=True;"
            );

            return new GimsDbContext(optionsBuilder.Options);
        }
    }
}