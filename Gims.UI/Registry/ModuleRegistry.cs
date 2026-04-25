using Gims.UI.Registry;

public static class ModuleRegistry
{
    private static readonly Dictionary<Guid, ModuleRegistration> _map = new();

    public static void Register(Guid id, Type componentType,
                                Dictionary<string, object>? parameters = null)
    {
        _map[id] = new ModuleRegistration(componentType, parameters);
    }

    public static ModuleRegistration Resolve(Guid id)
    {
        if (_map.TryGetValue(id, out var reg))
            return reg;

        throw new InvalidOperationException($"No module registered for ID {id}");
    }
}