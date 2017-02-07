using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MLD.Library.Constant;

namespace MVC.Exception
{
    public class PermissionFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RouteData.DataTokens.ContainsKey("area"))
            {
                string strAreaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                var controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
                if (strAreaName == "admin" && controller == "login")
                    return;
                if (!(filterContext.HttpContext.Request.Cookies.Get(UserCache.COOKIE) != null && filterContext.HttpContext.Session[UserCache.COOKIE] != null))
                {
                    filterContext.Result = new RedirectResult("../Login/Login");
                }
            }
        }
    }
}