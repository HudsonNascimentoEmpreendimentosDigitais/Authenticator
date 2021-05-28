using Flunt.Notifications;
using Hudson.Authenticator.Infra.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Hudson.Authenticator.Api.Controllers.Common
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ICollection<string> Errors = new List<string>();

        protected new ActionResult Response(ICommandResult result)
        {
            if (result != null && result.Success)
                return Ok(result);

            return BadRequest((IReadOnlyCollection<Notification>)result?.Data);
        }

        protected bool ValidOperation()
        {
            return !Errors.Any();
        }

        protected void AddErrorProcessing(string error)
        {
            Errors.Add(error);
        }

        protected void ClearErrorProcessing()
        {
            Errors.Clear();
        }
    }
}
