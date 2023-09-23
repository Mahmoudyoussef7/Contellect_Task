using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace App.Custom;

public class UserAuth : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var cookies = context.HttpContext.Request.Cookies;

        if (!cookies.ContainsKey("UserName"))
        {
            context.Result = new ForbidResult();
        }
    }
}
