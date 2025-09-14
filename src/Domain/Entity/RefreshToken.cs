using Domain.Entity;

namespace Core.Entity;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; }
    public bool IsValid => CreatedAt < ExpiresAt;
    public string TokenHash { get; set; } = string.Empty;
    public DateTime CreatedAt => DateTime.UtcNow;
    public DateTime ExpiresAt => DateTime.UtcNow.AddHours(2);
    public bool? Revoked;

}
