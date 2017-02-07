using System.Web.Mvc;
using MLD.IPresentation;
using MLD.Library.Constant;
using MVC.Controllers;

namespace MVC.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        /// <summary>
        /// 请求登陆视图 | Request login View
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CanLogin()
        {
            string username = Request.Form["username"];
            string pwd = Request.Form["pwd"];
            bool rs = Validate(username, pwd);
            if (!rs)
            {
                return AjaxMessage("用户名密码不能为空", MLD.Library.AjaxModel.AjaxModel.State.Error, null);
            }
            string result = GetService<ILogin>(ServiceName.LOGINKEY).Login(username,pwd);
            return AjaxMessage(result);
        }

    }
}
