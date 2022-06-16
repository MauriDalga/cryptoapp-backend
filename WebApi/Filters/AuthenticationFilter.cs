using System.Net;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;

namespace WebApi.Filters
{
    internal class AuthenticationFilter : BaseFilter, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var routeId = Regex.Match(context.HttpContext.Request.Path, @"\d+").Value;
            var queryUserId = context.HttpContext.Request.QueryString.Value != null
                ? Regex.Match(context.HttpContext.Request.QueryString.Value, @"\d+").Value
                : null;
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Result = new ObjectResult(
                    new
                    {
                        Message = "Incorrect format of header 'Authorization'.",
                    })
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                };
            }
            else
            {
                var sessionLogic = GetService<ISessionService>(context);
                var isValidAuthorization = sessionLogic.IsValidAuthorizationHeaderFormat(authorizationHeader);

                if (!isValidAuthorization)
                {
                    context.Result = new UnauthorizedObjectResult(
                    new
                    {
                        Message = "Incorrect format of header 'Authorization'.",
                    });
                }
                else
                {
                    var isValidAuthentication = sessionLogic.AuthenticateUser(authorizationHeader, routeId, queryUserId);

                    if (!isValidAuthentication)
                    {
                        context.Result = new UnauthorizedObjectResult(
                        new
                        {
                            Message = "Header 'Authorization' expired or invalid.",
                        });
                    }
                }
            }
        }
    }
}