namespace Gims.Contracts.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = "";
        public string? Email { get; set; }

        public bool IsActive { get; set; }

        // For UI: list of role codes
        public List<string> Roles { get; set; } = new();
    }
}