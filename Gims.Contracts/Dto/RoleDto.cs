namespace Gims.Contracts.Dto
{
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }

        // For UI: list of permission codes
        public List<string> Permissions { get; set; } = new();
    }
}