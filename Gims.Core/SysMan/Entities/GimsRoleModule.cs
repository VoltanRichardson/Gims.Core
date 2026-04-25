namespace Gims.Core.SysMan.Entities
{
    public class GimsRoleModule
    {
        public string RoleId { get; set; }
        public GimsUserRole Role { get; set; }

        public Guid ModuleId { get; set; }
        public GimsModule Module { get; set; }
    }
}