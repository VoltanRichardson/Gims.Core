using Microsoft.AspNetCore.Builder;

namespace Gims.App.Modules;

public static class BusinessModuleExtensions
{
    public static void RegisterGimsModules(this IApplicationBuilder app)
    {
        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Code = "billing",
            Name = "Billing"
        });

        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Code = "customer",
            Name = "Customer"
        });

        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Code = "policy",
            Name = "Policy"
        });

        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Code = "claims",
            Name = "Claims"
        });

        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Code = "docman",
            Name = "Document Manager"
        });

        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            Code = "report",
            Name = "Reports"
        });

        BusinessModuleRegistry.Register(new BusinessModule
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Code = "sysman",
            Name = "System Management"
        });
    }
}