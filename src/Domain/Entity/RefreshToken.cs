using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Entity;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public string TokenHash { get; set; }
    public DateTime CreatedAt => DateTime.UtcNow;
    public DateTime ExpiresAt => DateTime.UtcNow.AddHours(2);
    public bool? Revoked;
}
