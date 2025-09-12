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
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public bool EmailConfirmed { get; set; } = false;
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int FailedLoginAttempts
    {
        get => _failedLoginAttempts;
        set
        {
            if (value > 5)
                throw new ArgumentException("Você excedeu as tentativas de login.");
            _failedLoginAttempts = value;
        }
    }
    private int _failedLoginAttempts { get;set; }
    public ICollection<UserLoginAttempt> Attempts { get; set; } = new List<UserLoginAttempt>();
    public ICollection<Role> Roles { get; set; } = new HashSet<Role>();
    public ICollection<RefreshToken> Tokens { get; set; } = new List<RefreshToken>();

}
