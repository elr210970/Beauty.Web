using Beauty.Shared.DTOs.Base;

namespace Beauty.Shared.DTOs.User
{
    public class LogedInUserDto : BaseEntityDto
    {
        public string? Email { get; set; }

        public int RoleId { get; set; }
    }
}
