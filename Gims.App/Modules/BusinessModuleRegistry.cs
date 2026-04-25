namespace Gims.App.Modules;

public static class BusinessModuleRegistry
{
    private static readonly Dictionary<Guid, BusinessModule> _modules = new();

    public static void Register(BusinessModule module)
        => _modules[module.Id] = module;

    public static BusinessModule Resolve(Guid id)
        => _modules[id];
}