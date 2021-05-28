using Hudson.Authenticator.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Hudson.Authenticator.Api.Filters
{
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {

        private readonly IAccessTokenService _accessToken;

        public AuthorizationFilter(IAccessTokenService accessToken)
        {
            _accessToken = accessToken;
        }


        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                                     .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

            await ValidateAccess(context);

        }

        private async Task ValidateAccess(AuthorizationFilterContext context)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
