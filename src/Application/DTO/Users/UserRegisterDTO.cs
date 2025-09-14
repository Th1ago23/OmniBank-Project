namespace Application.DTO.Users;

public record UserRegisterDTO(string email, string password, string username, string phoneNumber, string cep, string complement, string number)
{
}
