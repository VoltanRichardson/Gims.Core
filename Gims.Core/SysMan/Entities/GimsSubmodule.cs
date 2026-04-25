public class GimsSubmodule
{
    public Guid Id { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string Route { get; set; } = "";
    public string Icon { get; set; } = "";
    public bool Visible { get; set; }
    public bool Active { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsImplemented { get; set; }
    public List<string> Roles { get; set; } = new();

    protected GimsSubmodule() { }

    public GimsSubmodule(string code, string name)
    {
        Code = code;
        Name = name;
    }
}