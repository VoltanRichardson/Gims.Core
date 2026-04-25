namespace Gims.UI.Registry;

public class UiModuleRegistry
{
    private readonly List<UiModule> _modules = new();

    public IReadOnlyList<UiModule> Modules => _modules;

    public void Register(UiModule module)
    {
        _modules.Add(module);
    }

    public UiModule? GetByCode(string code) =>
        _modules.FirstOrDefault(m => m.Code == code);
}