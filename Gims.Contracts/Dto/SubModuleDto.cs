namespace Gims.Contracts.Dto
{
    public class SubmoduleDto
    {
        public Guid Id { get; set; }

        // Identity
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        // Routing
        public string Route { get; set; } = "";

        // UI metadata
        public string Icon { get; set; } = "";

        // Visibility & state
        public bool Visible { get; set; }
        public bool Active { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsImplemented { get; set; }

        // Security (role codes)
        public List<string> Roles { get; set; } = new();
    }
}