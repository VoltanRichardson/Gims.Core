using Gims.UI;
using Gims.UI.Registry;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gims.UI.ShellUI.Workspace;

public class WorkspaceController
{
    private readonly UiModuleRegistry _registry;
    private readonly UiSessionState _uiState;

    public Guid InstanceId { get; } = Guid.NewGuid();

    public event Action? OnChange;

    public UiModule? CurrentModule { get; private set; }

    public List<UiModule> PermanentModules { get; }
    public List<UiModule> OpenBusinessModules { get; }

    public bool IsPickerOpen { get; private set; }

    public IEnumerable<UiModule> Tabs =>
        PermanentModules.OrderBy(m => m.Order)
                        .Concat(OpenBusinessModules.OrderBy(m => m.Order));

    public IEnumerable<UiModule> AvailableModules =>
        _registry.Modules
                 .Where(m => !m.IsPermanent)
                 .OrderBy(m => m.Order);

    public Dictionary<string, object?> CurrentParameters { get; set; }
    = new();

    public WorkspaceController(
        UiModuleRegistry registry,
        UiSessionState uiState)
    {
        _registry = registry;
        _uiState = uiState;

        PermanentModules = new();
        OpenBusinessModules = new();

        // TRACE
        Console.WriteLine($">>> WorkspaceController CTOR - InstanceId: {InstanceId}");
    }

    // ------------------------------------------------------------
    // Initialization
    // ------------------------------------------------------------

    public void Initialize()
    {
        Console.WriteLine($">>> WorkspaceController.Initialize - InstanceId: {InstanceId}");

        var permanent = _registry.Modules
            .Where(m => m.IsPermanent)
            .OrderBy(m => m.Order)
            .ToList();

        PermanentModules.Clear();
        PermanentModules.AddRange(permanent);

        Console.WriteLine($">>> WorkspaceController.Initialize - PermanentModules: {PermanentModules.Count}");

        if (PermanentModules.Any())
        {
            CurrentModule = PermanentModules.First();
            Console.WriteLine($">>> WorkspaceController.Initialize - CurrentModule: {CurrentModule.Code}");
        }

        Notify();
    }

    // ------------------------------------------------------------
    // Activation
    // ------------------------------------------------------------

    public void Activate(string code)
    {
        Console.WriteLine($">>> WorkspaceController.Activate(string) - code: {code}, InstanceId: {InstanceId}");

        var module = _registry.Modules.FirstOrDefault(m => m.Code == code);
        if (module is not null)
            Activate(module);
        else
            Console.WriteLine($">>> WorkspaceController.Activate(string) - module NOT FOUND: {code}");
    }

    // ----------------------------------------------------------------------
    // Compatibility helpers for existing UI components
    // ----------------------------------------------------------------------

    public UiModule? ActiveTab => CurrentModule;

    public UiModule? GetModule(string code)
    {
        Console.WriteLine($">>> WorkspaceController.GetModule - code: {code}, InstanceId: {InstanceId}");
        return _registry.Modules.FirstOrDefault(m => m.Code == code);
    }

    // ------------------------------------------------------------
    // Opening
    // ------------------------------------------------------------

    public void OpenModule(string code)
    {
        Console.WriteLine($">>> WorkspaceController.OpenModule - code: {code}, InstanceId: {InstanceId}");

        var mod = _registry.Modules.FirstOrDefault(m => m.Code == code);
        if (mod is null)
        {
            Console.WriteLine($">>> WorkspaceController.OpenModule - module NOT FOUND: {code}");
            return;
        }

        if (mod.IsPermanent)
        {
            Console.WriteLine($">>> WorkspaceController.OpenModule - permanent module: {mod.Code}");
            CurrentModule = mod;
        }
        else
        {
            Console.WriteLine($">>> WorkspaceController.OpenModule - business module: {mod.Code}");

            if (!OpenBusinessModules.Any(m => m.Code == mod.Code))
            {
                OpenBusinessModules.Add(mod);
                OpenBusinessModules.Sort((a, b) => a.Order.CompareTo(b.Order));
                Console.WriteLine($">>> WorkspaceController.OpenModule - OpenBusinessModules count: {OpenBusinessModules.Count}");
            }

            CurrentModule = mod;

            _uiState.RecentModules.Remove(code);
            _uiState.RecentModules.Add(code);
            if (_uiState.RecentModules.Count > 10)
                _uiState.RecentModules.RemoveAt(0);
        }

        IsPickerOpen = false;
        Notify();
    }

    public void Open(string code) => OpenModule(code);
    public void Open(UiModule module) => OpenModule(module.Code);
    public void Close(UiModule module) => CloseBusinessModule(module.Code);
    public void Activate(UiModule module)
    {
        Console.WriteLine($">>> WorkspaceController.Activate(UiModule) - {module.Code}, InstanceId: {InstanceId}");
        OpenModule(module.Code);
    }

    // ------------------------------------------------------------
    // Closing
    // ------------------------------------------------------------

    public void CloseBusinessModule(string code)
    {
        Console.WriteLine($">>> WorkspaceController.CloseBusinessModule - code: {code}, InstanceId: {InstanceId}");

        var mod = OpenBusinessModules.FirstOrDefault(m => m.Code == code);
        if (mod is null)
        {
            Console.WriteLine($">>> WorkspaceController.CloseBusinessModule - module NOT FOUND in OpenBusinessModules: {code}");
            return;
        }

        OpenBusinessModules.Remove(mod);
        Console.WriteLine($">>> WorkspaceController.CloseBusinessModule - remaining OpenBusinessModules: {OpenBusinessModules.Count}");

        if (CurrentModule?.Code == code)
        {
            if (OpenBusinessModules.Any())
            {
                CurrentModule = OpenBusinessModules.Last();
                Console.WriteLine($">>> WorkspaceController.CloseBusinessModule - CurrentModule switched to last business: {CurrentModule.Code}");
            }
            else
            {
                CurrentModule = PermanentModules.FirstOrDefault();
                Console.WriteLine($">>> WorkspaceController.CloseBusinessModule - CurrentModule switched to first permanent: {CurrentModule?.Code}");
            }
        }

        Notify();
    }

    public void CloseAllBusinessModules()
    {
        Console.WriteLine($">>> WorkspaceController.CloseAllBusinessModules - InstanceId: {InstanceId}");

        OpenBusinessModules.Clear();
        CurrentModule = PermanentModules.FirstOrDefault();
        Console.WriteLine($">>> WorkspaceController.CloseAllBusinessModules - CurrentModule: {CurrentModule?.Code}");

        Notify();
    }

    public void CloseOtherModules(UiModule keep)
    {
        Console.WriteLine($">>> WorkspaceController.CloseOtherModules - keep: {keep.Code}, InstanceId: {InstanceId}");

        OpenBusinessModules.RemoveAll(m => m.Code != keep.Code);
        CurrentModule = keep;
        Console.WriteLine($">>> WorkspaceController.CloseOtherModules - remaining OpenBusinessModules: {OpenBusinessModules.Count}");

        Notify();
    }

    // ------------------------------------------------------------
    // Picker
    // ------------------------------------------------------------

    public void ShowPicker()
    {
        Console.WriteLine($">>> WorkspaceController.ShowPicker - InstanceId: {InstanceId}");
        
        IsPickerOpen = true;
        Notify();
    }

    public void HidePicker()
    {
        Console.WriteLine($">>> WorkspaceController.HidePicker - InstanceId: {InstanceId}");
        IsPickerOpen = false;
        Notify();
    }

    // ------------------------------------------------------------
    // Reorder
    // ------------------------------------------------------------

    public void Reorder(int oldIndex, int newIndex)
    {
        Console.WriteLine($">>> WorkspaceController.Reorder - {oldIndex} -> {newIndex}, InstanceId: {InstanceId}");

        if (oldIndex < 0 || newIndex < 0) return;
        if (oldIndex >= OpenBusinessModules.Count || newIndex >= OpenBusinessModules.Count) return;

        var item = OpenBusinessModules[oldIndex];
        OpenBusinessModules.RemoveAt(oldIndex);
        OpenBusinessModules.Insert(newIndex, item);

        Notify();
    }

    // ------------------------------------------------------------
    // Notify (UI-safe)
    // ------------------------------------------------------------

    public void Notify()
    {
        Console.WriteLine($">>> WorkspaceController.Notify - InstanceId: {InstanceId}, " +
                          $"Permanent: {PermanentModules.Count}, OpenBusiness: {OpenBusinessModules.Count}, " +
                          $"Current: {CurrentModule?.Code}, IsPickerOpen: {IsPickerOpen}");

        OnChange?.Invoke();
    }
}