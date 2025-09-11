using Core.Entity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class User
{
    public User()
    {}

    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int FailedLoginAttempts
    {
        get { return FailedLoginAttempts; }
        set
        {
            if (FailedLoginAttempts >= 5) throw new ArgumentException("Você excedeu as tentativas de login");
        }
    }
    public ICollection<UserLoginAttempt> Attempts { get; set; }
    public ICollection<Role> Roles { get; set; }
    public RefreshToken Token { get; set; }

    
    public User (Guid id, string username, string email, string passwordhash)
    {
        Id = id;
        Username = username;
        Email = email;
        PasswordHash = passwordhash;
        CreatedAt = DateTime.UtcNow;
    }

}
