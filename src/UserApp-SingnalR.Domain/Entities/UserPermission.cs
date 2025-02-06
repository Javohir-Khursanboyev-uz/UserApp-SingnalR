namespace UserApp_SingnalR.Domain.Entities;

public class UserPermission 
{ 
    public long Id { get; set; }
    public long RoleId { get; set; }
    public UserRole Role { get; set; }
    public long PermissionId { get; set; }
    public Permission Permission { get; set; }
}
