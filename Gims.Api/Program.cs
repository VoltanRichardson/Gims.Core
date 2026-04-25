using Gims.Api.Services.SysMan;
using Gims.App.AppState;
using Gims.Core.SysMan.Entities;
using Gims.Infrastructure.EF;
using Gims.Infrastructure.EF.Configurations.SysMan;
using Gims.Infrastructure.EF.Configurations.SysMan.Seed;
using Gims.Contracts.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // DbContext
        builder.Services.AddDbContext<GimsDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // Identity
        builder.Services.AddIdentity<GimsUser, GimsUserRole>()
            .AddEntityFrameworkStores<GimsDbContext>()
            .AddDefaultTokenProviders();

        // Controllers
        builder.Services.AddControllers();

        //Services
        builder.Services.AddScoped<IModuleAdminService, ModuleAdminService>();
        builder.Services.AddScoped<IUserAdminService, UserAdminService>();
        builder.Services.AddScoped<ISubmoduleAdminService, SubmoduleAdminService>();
        builder.Services.AddScoped<IRoleAdminService, RoleAdminService>();
        
        // Current User
        builder.Services.AddHttpContextAccessor();
        //builder.Services.AddScoped<ICurrentUser, CurrentUser>();

        // Seeder
        builder.Services.AddSingleton<SeedState>();
        builder.Services.AddScoped<SysManSeeder>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<SysManSeeder>();
            var seedState = scope.ServiceProvider.GetRequiredService<SeedState>();

            await seeder.SeedAsync();
            seedState.AdminId = seeder.SeededAdminId;
        }
        app.MapControllers();
        app.Run();
    }
}