
namespace Gims.Contracts.Dto
{
    public class ModuleDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = "";     // Code
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string RoutePrefix { get; set; } = "";
        public string DefaultRoute { get; set; } = "";

        public string Icon { get; set; } = "";
        public string Category { get; set; } = string.Empty;
        public string? LayoutType { get; set; }

        public bool Visible { get; set; }
        public bool Active { get; set; }
        public bool IsPublic { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsImplemented { get; set; }
        public bool IsComingSoon { get; set; }

        public int TabPriority { get; set; }

        public List<string> Roles { get; set; } = new();

        public List<SubmoduleDto> Submodules { get; set; } = new();
    }
}