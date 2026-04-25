namespace Gims.Core.SysMan.Entities
{
    public class GimsModule
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        public string RoutePrefix { get; set; } = "";
        public string DefaultRoute { get; set; } = "";

        public string Icon { get; set; } = "";

        public string? Category { get; set; }
        public string? LayoutType { get; set; }

        public bool Visible { get; set; }
        public bool Active { get; set; }
        public bool IsPublic { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsImplemented { get; set; }

        public List<string> Roles { get; set; } = new();
        public List<GimsSubmodule> Submodules { get; set; }

        // EF Core constructor
        protected GimsModule() { }

        // Domain constructor
        public GimsModule(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}