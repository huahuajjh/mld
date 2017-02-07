using System.Data.Entity.Validation;
using System.Web.Mvc;

namespace MVC.Exception
{
    public class CatchGlobalException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var v = filterContext.Exception;
            if (v is DbEntityValidationException)
            {
                throw v as DbEntityValidationException;
            }
            else
            {
                throw v;
            }
        }
    }
}