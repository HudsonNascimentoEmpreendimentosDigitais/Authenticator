using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Hudson.Authenticator.Infra.Identity.Services
{
    public class AccessTokenService
    {
        private readonly IHttpContextAccessor _accessor;

        public AccessTokenService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public AccessTokenService()
        {

        }

        public virtual string SessionId
        {
            get { return GetClaim("SessionId"); }
        }

        public virtual ClaimsIdentity ClaimsIdentityToken
        {
            get
            {
                return GetClaims();
            }
        }

        private string GetClaim(string propert)
        {
            if (!_accessor.HttpContext.User.Identity.IsAuthenticated)
                return string.Empty;

            var identity = (ClaimsIdentity)_accessor.HttpContext.User.Identity;
            return identity.Claims.FirstOrDefault(claim => claim.Type == propert)?.Value ?? string.Empty;
        }

        private ClaimsIdentity GetClaims()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated ?
                (ClaimsIdentity)_accessor.HttpContext.User.Identity : null;
        }

    }
}
