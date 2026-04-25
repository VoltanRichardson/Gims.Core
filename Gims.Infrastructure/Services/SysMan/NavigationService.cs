using Gims.Core.SysMan.Entities;
using Gims.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace Gims.Infrastructure.Services.SysMan
{
    public class NavigationService
    {
        private readonly GimsDbContext _db;

        public NavigationService(GimsDbContext db)
        {
            _db = db;
        }

        // ------------------------------------------------------------
        // GET AVAILABLE MODULES FOR USER (BY ROLE CODES)
        // ------------------------------------------------------------
        public async Task<List<GimsModule>> GetAvailableModulesAsync(List<string> roleCodes)
        {
            var modules = await _db.Modules
                .Where(m =>
                    m.Active &&
                    m.IsEnabled &&
                    m.Visible &&
                    (m.IsPublic || m.Roles.Any(r => roleCodes.Contains(r)))
                )
                .OrderBy(m => m.Name)
                .ToListAsync();

            return modules;
        }

        // ------------------------------------------------------------
        // GET AVAILABLE SUBMODULES FOR USER (BY ROLE CODES)
        // ------------------------------------------------------------
        public async Task<List<GimsSubmodule>> GetAvailableSubmodulesAsync(Guid moduleId, List<string> roleCodes)
        {
            var module = await _db.Modules.FirstOrDefaultAsync(m => m.Id == moduleId);
            if (module is null)
                return new List<GimsSubmodule>();

            return module.Submodules
                .Where(s =>
                    s.Active &&
                    s.IsEnabled &&
                    s.Visible &&
                    s.Roles.Any(r => roleCodes.Contains(r))
                )
                .OrderBy(s => s.Name)
                .ToList();
        }
    }
}