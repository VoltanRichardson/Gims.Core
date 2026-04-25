using Microsoft.AspNetCore.Components;

namespace Gims.UI.Registry;

public static class UiModuleRegistryExtensions
{
    public static UiModuleRegistry AddModule<TComponent>(
        this UiModuleRegistry registry,
        string code,
        string name,
        string icon = "",
        bool isPermanent = false,
        int order = 0,
        string category = "General",
        string[]? requiredPermissions = null,
        Dictionary<string, object>? parameters = null)
        where TComponent : IComponent
    {
        registry.Register(new UiModule
        {
            Id = Guid.NewGuid(),
            Code = code,
            Name = name,
            Icon = icon,
            IsPermanent = isPermanent,
            Order = order,
            Category = category,
            RequiredPermissions = requiredPermissions ?? Array.Empty<string>(),
            Component = typeof(TComponent),
            ComponentParameters = parameters
        });

        return registry;
    }
}