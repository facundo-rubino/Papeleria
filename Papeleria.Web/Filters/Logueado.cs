using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures; 

namespace Papeleria.Web.Filters
{
    public class Logueado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("email")))
            {
                string mensaje = Uri.EscapeDataString("Por favor, realizá el login");
                context.Result = new RedirectResult($"/Usuario/Login?mensaje={mensaje}");
                return;
            }
        }
    }
}

