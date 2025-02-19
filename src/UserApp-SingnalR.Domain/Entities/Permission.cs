using UserApp_SingnalR.Domain.Commons;

namespace UserApp_SingnalR.Domain.Entities;

public class Permission : Auditable
{
    public string Controller { get; set; }
    public string Action { get; set; }
}
