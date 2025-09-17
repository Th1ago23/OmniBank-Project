namespace Domain.Interface.Http;

public interface IContextUser
{
    Guid? UserId { get; }
    string UserEmail { get; }
}
