namespace Gims.Core.Domain.Workflow;

public class FunctionTask
{
    public Guid FunctionTaskId { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }
    public string? Description { get; private set; }

    // Optional: route or UI action
    public string? Route { get; private set; }

    // Optional: permission key
    public string? PermissionKey { get; private set; }

    // Foreign key to FunctionGroup
    public Guid FunctionGroupId { get; private set; }

    private FunctionTask() { } // EF Core

    public FunctionTask(
        string name,
        string? description = null,
        string? route = null,
        string? permissionKey = null)
    {
        Name = name;
        Description = description;
        Route = route;
        PermissionKey = permissionKey;
    }

    public void UpdateRoute(string route) => Route = route;
    public void UpdatePermission(string permission) => PermissionKey = permission;
}