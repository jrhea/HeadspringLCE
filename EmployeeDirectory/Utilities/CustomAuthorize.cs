using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;


namespace EmployeeDirectory.Utilities
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = false;
            ModelHelper modelHelper = (ModelHelper)httpContext.Session["ModelHelper"];
            if(Roles.Contains(modelHelper.SessionIdentityRole.Description))
            {
                result = true;
            }
                
            return result;
        }
    }
}