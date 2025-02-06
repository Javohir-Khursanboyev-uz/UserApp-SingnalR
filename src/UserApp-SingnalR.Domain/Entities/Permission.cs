namespace UserApp_SingnalR.Domain.Entities;

public class Permission
{
    public long Id { get; set; }
    public string Controller { get; set; }
    public string Action { get; set; }
}
