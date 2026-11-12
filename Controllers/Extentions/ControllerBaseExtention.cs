using System.Linq;
using System.Net;
using System.Security.Claims;
using SWAPI.SERVICES;
//using SWAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SWAPI.Controllers
{
    public static class ControllerBaseExtensions
    {

        public static ActionResult FromServiceOperationResult<TData>(
            this ControllerBase controllerBase, ServiceOperationResult<TData> result
        )
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return controllerBase.Ok(result.Data);

                case HttpStatusCode.Accepted:
                    return controllerBase.Accepted();

                case HttpStatusCode.Unauthorized:
                    return controllerBase.Unauthorized();

                case HttpStatusCode.NoContent:
                    return controllerBase.NoContent();

                case HttpStatusCode.Conflict:
                    return controllerBase.Conflict(result.Data);

                case HttpStatusCode.NotFound:
                case HttpStatusCode.UnprocessableEntity:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                    return controllerBase.StatusCode((int)result.StatusCode, result.Errors);

                default:
                    return controllerBase.BadRequest(result.Errors);
            }
        }

        public static ActionResult FromServiceOperationResult(
            this ControllerBase controllerBase, ServiceOperationResult result
        )
        {
            switch (result.StatusCode)
            {
                case HttpStatusCode.OK:
                    return controllerBase.Ok();
                case HttpStatusCode.Accepted:
                    return controllerBase.Accepted();
                case HttpStatusCode.NoContent:
                    return controllerBase.NoContent();

                case HttpStatusCode.Unauthorized:
                    return controllerBase.Unauthorized();
                case HttpStatusCode.Conflict:
                    return controllerBase.Conflict(result);
                case HttpStatusCode.NotFound:
                case HttpStatusCode.UnprocessableEntity:
                case HttpStatusCode.InternalServerError:
                case HttpStatusCode.NotImplemented:
                    return controllerBase.StatusCode((int)result.StatusCode, result.Errors);
                default:
                    return controllerBase.BadRequest(result.Errors);
            }
        }
    }
}