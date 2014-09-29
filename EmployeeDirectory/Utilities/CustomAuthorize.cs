using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;


namespace EmployeeDirectory.Utilities
{
    /// <summary>
    /// Custom attribute to assist in authorization of views
    /// </summary>
    public class CustomAuthorize : AuthorizeAttribute
    {

        /// <summary>
        /// Method handles the authorization
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>True if the user is authorized to see the view; otherwise, False.</returns>
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