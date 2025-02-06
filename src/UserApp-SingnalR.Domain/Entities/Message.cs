using UserApp_SingnalR.Domain.Commons;

namespace UserApp_SingnalR.Domain.Entities;

public class Message : Auditable
{
    public long ContactId { get; set; }
    public Contact Contact { get; set; }
    public  string Text { get; set; }
    public long? ContentId {  get; set; } 
    public Asset Content { get; set; }
}
