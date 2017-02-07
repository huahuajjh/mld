using System;
using System.Web.Mvc;
using MLD.Entity;
using MLD.Library.Constant;
using MVC.Controllers;

namespace MVC.Areas.Admin.Controllers
{
    public class IndexController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
