using Microsoft.AspNetCore.Identity;

namespace Gims.Core.SysMan.Entities
{
    public class GimsUser : IdentityUser

    {        
        public bool IsActive { get; set; } = true;

        // Audit
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }

        // Domain does NOT reference roles directly
        // Relationship is handled by a join entity in Infrastructure

    }
}