using Gims.App.AppState;
using Gims.UI;
using Gims.UI.Components;
using Gims.UI.Registry;
using Gims.UI.ShellUI.Workspace;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------
// 1. Blazor + Fluent + App Services
// ------------------------------------------------------------
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();

// Unified module registry
builder.Services.AddUiModuleMetadata();

// User + App state
builder.Services.AddScoped<UserContextService>();
builder.Services.AddScoped<AppState>();

// UI session + UI state
builder.Services.AddSingleton<UiSessionState>();
builder.Services.AddScoped<UserInterfaceState>();

// ------------------------------------------------------------
// 2. WorkspaceController (CONSTRUCTION ONLY — NO LOGIC HERE)
// ------------------------------------------------------------
builder.Services.AddSingleton<WorkspaceController>(sp =>
{
    Console.WriteLine(">>> DI: Constructing WorkspaceController");

    var registry = sp.GetRequiredService<UiModuleRegistry>();
    var uiState = sp.GetRequiredService<UiSessionState>();

    var wc = new WorkspaceController(registry, uiState);

    Console.WriteLine($">>> DI: WorkspaceController constructed - InstanceId: {wc.InstanceId}");

    return wc;
});

// ------------------------------------------------------------
// 3. Build the app
// ------------------------------------------------------------
var app = builder.Build();

// ------------------------------------------------------------
// 4. Initialize WorkspaceController AFTER host is built
// ------------------------------------------------------------
Console.WriteLine(">>> App Startup: Resolving WorkspaceController for initialization");

var workspace = app.Services.GetRequiredService<WorkspaceController>();

Console.WriteLine($">>> App Startup: Calling WorkspaceController.Initialize - InstanceId: {workspace.InstanceId}");

workspace.Initialize();

Console.WriteLine(">>> App Startup: WorkspaceController initialization complete");

// ------------------------------------------------------------
// 5. Standard pipeline
// ------------------------------------------------------------
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();