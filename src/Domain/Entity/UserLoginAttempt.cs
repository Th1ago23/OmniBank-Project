using Domain.Entity;

namespace Core.Entity;

public class UserLoginAttempt
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime TimeStamp { get; set; }
    public string IpAdress { get; set; } = string.Empty;
    public string UserAgent { get; set; }
}
