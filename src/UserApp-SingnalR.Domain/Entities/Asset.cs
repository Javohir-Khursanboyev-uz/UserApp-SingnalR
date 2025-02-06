using UserApp_SingnalR.Domain.Commons;
using UserApp_SingnalR.Domain.Enums;

namespace UserApp_SingnalR.Domain.Entities;

public class Asset : Auditable
{
    public string Name { get; set; }
    public string Path { get; set; }
    public FileType FileType { get; set; }
}
