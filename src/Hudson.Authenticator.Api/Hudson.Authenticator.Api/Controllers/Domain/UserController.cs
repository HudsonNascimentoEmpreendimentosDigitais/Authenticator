using Hudson.Authenticator.Api.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Hudson.Authenticator.Api.Controllers.Domain
{

    [Route("v{version:apiVersion}/users")]
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
