using UserApp_SingnalR.Domain.Commons;

namespace UserApp_SingnalR.Domain.Entities;

public class UserRole : Auditable
{
    public string Name { get; set; }
}
