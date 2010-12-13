using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileWizard.Domain.Repositories;

namespace AgileWizard.Website
{
    public class RequireAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //redirect if not authenticated
            if (SessionStateRepository.Instance.IsLoggedIn == false)
            {
                const string loginUrl = "/Account/Logon";
                filterContext.HttpContext.Response.Write(string.Format("<script>top.location.href='{0}';</script>"
                    , loginUrl
                    ));
            }
        }
    }
}