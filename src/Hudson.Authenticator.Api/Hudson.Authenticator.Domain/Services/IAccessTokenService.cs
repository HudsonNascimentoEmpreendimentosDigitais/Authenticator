using System.Security.Claims;

namespace Hudson.Authenticator.Domain.Services
{
    public interface IAccessTokenService
    {
        long UserId { get; }
        string SessionId { get; }
        ClaimsIdentity ClaimsIdentityToken { get; }
    }
}
