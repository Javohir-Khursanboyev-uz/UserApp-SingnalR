using UserApp_SingnalR.Domain.Commons;

namespace UserApp_SingnalR.Domain.Entities;

public class Contact : Auditable
{
    public long OwnerId { get; set; }
    public User Owner { get; set; }
    public long TargetUserId{ get; set; }
    public User TargetUser { get; set; }
    public string AliasName { get; set; }
    public IEnumerable<Message> Messages { get; set; }
}
