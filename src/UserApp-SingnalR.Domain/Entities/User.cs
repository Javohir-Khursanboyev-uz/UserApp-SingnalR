using UserApp_SingnalR.Domain.Commons;

namespace UserApp_SingnalR.Domain.Entities;

public class User : Auditable
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public long PictureId { get; set; }
    public Asset Picture { get; set; }
    public long RoleId { get; set; }
    public UserRole Role { get; set; }
    public IEnumerable<Contact> Contacts { get; set; }
}