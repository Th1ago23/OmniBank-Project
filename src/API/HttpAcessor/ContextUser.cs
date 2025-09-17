using Domain.Interface.Http;
using System.Security.Claims;

namespace API.HttpAcessor;

public class ContextUser(IHttpContextAccessor acessor) : IContextUser
{
    private readonly IHttpContextAccessor _acessor = acessor;

    public Guid? UserId
    {
        get
        {
            var userIdString = _acessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return string.IsNullOrEmpty(userIdString) ? null : Guid.Parse(userIdString);
        }
    }
    public string? UserEmail => _acessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
}
