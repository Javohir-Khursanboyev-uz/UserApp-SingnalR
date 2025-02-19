using UserApp_SingnalR.Domain.Commons;

namespace UserApp_SingnalR.Domain.Entities;

public class RolePermission : Auditable
{ 
    public long RoleId { get; set; }
    public UserRole Role { get; set; }
    public long PermissionId { get; set; }
    public Permission Permission { get; set; }
}
