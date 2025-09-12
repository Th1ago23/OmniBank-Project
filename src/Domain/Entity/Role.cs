using Domain.Entity;

namespace Core.Entity;

public class Role
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public RolesName Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();


}
