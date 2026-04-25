using Gims.Core.SysMan.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Gims.Infrastructure.EF.Configurations.SysMan.Seed;

public class SysManSeeder
{
    private readonly GimsDbContext _db;
    private readonly UserManager<GimsUser> _userManager;
    private readonly RoleManager<GimsUserRole> _roleManager;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<SysManSeeder> _log;

    public SysManSeeder(
        GimsDbContext db,
        UserManager<GimsUser> userManager,
        RoleManager<GimsUserRole> roleManager,
        IWebHostEnvironment env,
        ILogger<SysManSeeder> log)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
        _env = env;
        _log = log;
    }

    public Guid SeededAdminId { get; private set; }

    public async Task SeedAsync()
    {
        var modules = await SeedModulesAsync();          // returns List<GimsModule>
        var roles = await SeedRolesAsync(modules);       // returns List<string>
        await SeedAdminUserAsync(roles);
        await SeedRoleModulesAsync(modules, roles);
    }

    private async Task<List<GimsModule>> SeedModulesAsync()
    {
        var folder = Path.Combine(_env.ContentRootPath, "Modules");
        if (!Directory.Exists(folder))
            return new List<GimsModule>();

        var files = Directory.GetFiles(folder, "*.json");
        var allModules = new List<GimsModule>();

        foreach (var file in files)
        {
            var json = await File.ReadAllTextAsync(file);

            var incoming = JsonSerializer.Deserialize<GimsModule>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (incoming == null || string.IsNullOrWhiteSpace(incoming.Code))
                continue;

            allModules.Add(incoming);

            //var existing = await _db.Modules
            //    .Include(m => m.Submodules)
            //    .FirstOrDefaultAsync(m => m.Id == incoming.Id);

            var existing = await _db.Modules.FirstOrDefaultAsync(m => m.Code == incoming.Code);


            if (existing == null)
            {
                incoming.Id = incoming.Id == Guid.Empty ? Guid.NewGuid() : incoming.Id;

                if (incoming.Submodules != null)
                {
                    foreach (var sub in incoming.Submodules)
                        sub.Id = sub.Id == Guid.Empty ? Guid.NewGuid() : sub.Id;
                }

                _db.Modules.Add(incoming);
                _log.LogInformation("Seeded module: {Code}", incoming.Code);
            }
            else
            {
                existing.Name = incoming.Name;
                existing.Description = incoming.Description;
                existing.RoutePrefix = incoming.RoutePrefix;
                existing.DefaultRoute = incoming.DefaultRoute;
                existing.Icon = incoming.Icon;
                existing.LayoutType = incoming.LayoutType;
                existing.Visible = incoming.Visible;
                existing.Active = incoming.Active;
                existing.IsPublic = incoming.IsPublic;
                existing.IsEnabled = incoming.IsEnabled;
                existing.IsImplemented = incoming.IsImplemented;
                existing.Category = incoming.Category;
                existing.Roles = incoming.Roles;

                if (incoming.Submodules != null)
                {
                    foreach (var sub in incoming.Submodules)
                        sub.Id = sub.Id == Guid.Empty ? Guid.NewGuid() : sub.Id;

                    existing.Submodules = incoming.Submodules;
                }
                else
                {
                    existing.Submodules = new List<GimsSubmodule>();
                }

                _db.Modules.Update(existing);
                _log.LogInformation("Updated module: {Code}", incoming.Code);
            }
        }

        await _db.SaveChangesAsync();
        return allModules;
    }

    //private async Task<List<GimsModule>> SeedModulesAsync()
    //{
    //    var folder = Path.Combine(_env.ContentRootPath, "Modules");
    //    if (!Directory.Exists(folder))
    //        return new List<GimsModule>();

    //    var file = Path.Combine(folder, "modules.json");
    //    if (!File.Exists(file))
    //        return new List<GimsModule>();

    //    var json = await File.ReadAllTextAsync(file);

    //    var modules = JsonSerializer.Deserialize<List<GimsModule>>(json,
    //        new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
    //        ?? new List<GimsModule>();

    //    foreach (var incoming in modules)
    //    {
    //        if (string.IsNullOrWhiteSpace(incoming.Code))
    //            continue;

    //        var existing = await _db.Modules.FirstOrDefaultAsync(m => m.Code == incoming.Code);

    //        if (existing == null)
    //        {
    //            incoming.Id = incoming.Id == Guid.Empty ? Guid.NewGuid() : incoming.Id;

    //            if (incoming.Submodules != null)
    //            {
    //                foreach (var sub in incoming.Submodules)
    //                    sub.Id = sub.Id == Guid.Empty ? Guid.NewGuid() : sub.Id;
    //            }

    //            _db.Modules.Add(incoming);
    //            _log.LogInformation("Seeded module: {Code}", incoming.Code);
    //        }
    //        else
    //        {
    //            existing.Name = incoming.Name;
    //            existing.Description = incoming.Description;
    //            existing.RoutePrefix = incoming.RoutePrefix;
    //            existing.DefaultRoute = incoming.DefaultRoute;
    //            existing.Icon = incoming.Icon;
    //            existing.LayoutType = incoming.LayoutType;
    //            existing.Visible = incoming.Visible;
    //            existing.Active = incoming.Active;
    //            existing.IsPublic = incoming.IsPublic;
    //            existing.IsEnabled = incoming.IsEnabled;
    //            existing.IsImplemented = incoming.IsImplemented;
    //            existing.Roles = incoming.Roles;

    //            if (incoming.Submodules != null)
    //            {
    //                foreach (var sub in incoming.Submodules)
    //                    sub.Id = sub.Id == Guid.Empty ? Guid.NewGuid() : sub.Id;

    //                existing.Submodules = incoming.Submodules;
    //            }
    //            else
    //            {
    //                existing.Submodules = new List<GimsSubmodule>();
    //            }

    //            _db.Modules.Update(existing);
    //            _log.LogInformation("Updated module: {Code}", incoming.Code);
    //        }
    //    }

    //    await _db.SaveChangesAsync();
    //    return modules;
    //}

    private async Task<List<string>> SeedRolesAsync(List<GimsModule> modules)
    {
        var roles = modules
            .SelectMany(m => m.Roles ?? new List<string>())
            .Concat(
                modules.SelectMany(m =>
                    (m.Submodules ?? new List<GimsSubmodule>())
                        .SelectMany(s => s.Roles ?? new List<string>())
                )
            )
            .Distinct()
            .ToList();

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new GimsUserRole { Name = role });
        }

        return roles;
    }

     private async Task SeedAdminUserAsync(List<string> roles)
    {
        var admin = await _userManager.FindByNameAsync("admin");

        if (admin == null)
        {
            admin = new GimsUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                Email = "admin@gims.local"
            };

            var result = await _userManager.CreateAsync(admin, "ChangeMe123!");
            if (!result.Succeeded)
                throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

            SeededAdminId = Guid.Parse(admin.Id);
        }
        else
        {
            SeededAdminId = Guid.Parse(admin.Id);
        }

        foreach (var role in roles)
        {
            if (!await _userManager.IsInRoleAsync(admin, role))
                await _userManager.AddToRoleAsync(admin, role);
        }
    }
    private async Task SeedRoleModulesAsync(List<GimsModule> modules, List<string> roles)
    {
        // Load actual Identity roles (Id + Name)
        var identityRoles = await _roleManager.Roles.ToListAsync();

        foreach (var module in modules)
        {
            foreach (var roleName  in roles)
            {
                var identityRole = identityRoles.FirstOrDefault(r => r.Name == roleName);
                if (identityRole == null)
                    continue; // should never happen

                var exists = await _db.RoleModules
                    .AnyAsync(rm => rm.RoleId == identityRole.Id && rm.ModuleId == module.Id);

                if (!exists)
                {
                    _db.RoleModules.Add(new GimsRoleModule
                    {
                        RoleId = identityRole.Id,   // GUID, not name
                        ModuleId = module.Id
                    });
                }
            }
        }

        await _db.SaveChangesAsync();
    }
}