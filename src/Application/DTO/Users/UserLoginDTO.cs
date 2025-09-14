using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Users;

public record UserLoginDTO([EmailAddress] string email, string password)
{ }
