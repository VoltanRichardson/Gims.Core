namespace Gims.UI.Registry;

public class ModuleRegistration
{
    public Type ComponentType { get; }
    public Dictionary<string, object>? DefaultParameters { get; }

    public ModuleRegistration(Type componentType,
                              Dictionary<string, object>? parameters = null)
    {
        ComponentType = componentType;
        DefaultParameters = parameters;
    }
}