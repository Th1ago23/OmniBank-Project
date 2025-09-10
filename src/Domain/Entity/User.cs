using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class User
{
    public User()
    {

    }
    [Key]
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Passwordhash { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
    public DateTime CreatedAt => DateTime.Now;
    public DateTime UpdatedAt { get; set; }
    public int FailedLoginAttempts
    {
        get { return FailedLoginAttempts; }
        set
        {
            if (FailedLoginAttempts >= 5) throw new ArgumentException("Você excedeu as tentativas de login");
        }
    }

    public User (Guid id, string username, string email, string passwordhash)
    {
        Id = id;
        Username = username;
        Email = email;
        Passwordhash = passwordhash;
    }

}
