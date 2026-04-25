using Microsoft.Extensions.DependencyInjection;

namespace Gims.UI.Registry;

public static class ModuleRegistryExtensions
{
    public static IServiceCollection AddUiModuleMetadata(this IServiceCollection services)
    {
        services.AddSingleton<UiModuleRegistry>(_ => 
        {
            var registry = new UiModuleRegistry();

            //
            // PERMANENT MODULES (always visible, no close button)
            //
            registry.Register(new UiModule
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Code = "dashboard",
                Name = "Dashboard",
                Icon = "🏠",
                Component = typeof(Gims.UI.Modules.Dashboard.DashboardUI),
                IsPermanent = true,
                Order = -20,
                Category = "System"
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                Code = "activity",
                Name = "Activity",
                Icon = "📈",
                Component = typeof(Gims.UI.Modules.Activity.ActivityUI),
                IsPermanent = true,
                Order = -10,
                Category = "System"
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Code = "sysman-admin",
                Name = "System Admin",
                Icon = "⚙️",
                Component = typeof(Gims.UI.Modules.SysMan.SysManModule),
                IsPermanent = false,
                Order = 0,
                Category = "System",
                RequiredPermissions = new[] { "sysman.access" }
            });

            //
            // BUSINESS MODULES (open/close tabs)
            //
            registry.Register(new UiModule
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Code = "billing",
                Name = "Billing",
                Icon = "🧾",
                Component = typeof(Gims.UI.Modules.Billing.BillingUI),
                IsPermanent = false,
                Order = 10,
                Category = "Business",
                RequiredPermissions = new[] { "billing.read" }
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Code = "customer",
                Name = "Customer",
                Icon = "👤",
                Component = typeof(Gims.UI.Modules.Customer.CustomerUI),
                IsPermanent = false,
                Order = 20,
                Category = "Business",
                RequiredPermissions = new[] { "customer.read" }
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Code = "policy",
                Name = "Policy",
                Icon = "📝",
                Component = typeof(Gims.UI.Modules.Policy.PolicyUI),
                IsPermanent = false,
                Order = 30,
                Category = "Business",
                RequiredPermissions = new[] { "policy.read" }
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Code = "claims",
                Name = "Claims",
                Icon = "⚖️",
                Component = typeof(Gims.UI.Modules.Claims.ClaimsUI),
                IsPermanent = false,
                Order = 40,
                Category = "Business",
                RequiredPermissions = new[] { "claims.read" }
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Code = "docman",
                Name = "Document Manager",
                Icon = "📁",
                Component = typeof(Gims.UI.Modules.DocMan.DocManUI),
                IsPermanent = false,
                Order = 50,
                Category = "Tools"
            });

            registry.Register(new UiModule
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Code = "report",
                Name = "Reports",
                Icon = "📊",
                Component = typeof(Gims.UI.Modules.Report.ReportUI),
                IsPermanent = false,
                Order = 60,
                Category = "Tools"
            });

            return registry;
        });

        return services;
    }
}