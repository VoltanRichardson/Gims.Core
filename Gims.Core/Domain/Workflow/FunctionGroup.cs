namespace Gims.Core.Domain.Workflow;

public class FunctionGroup
{
    public Guid FunctionGroupId { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; }
    public string? Description { get; private set; }

    private readonly List<FunctionTask> _tasks = new();
    public IReadOnlyCollection<FunctionTask> Tasks => _tasks.AsReadOnly();

    private FunctionGroup() { } // EF Core

    public FunctionGroup(string name, string? description = null)
    {
        Name = name;
        Description = description;
    }

    public void AddTask(FunctionTask task)
    {
        if (task == null)
            throw new ArgumentNullException(nameof(task));

        _tasks.Add(task);
    }
}