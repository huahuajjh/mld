using System.Linq;
using System.Web;
using MLD.Entity;
using MLD.IPresentation;
using MLD.Library.Constant;

namespace MLD.Domain.Login
{
    public class LoginImpl : Base, ILogin
    {
        public string Login(string username, string pwd, bool remember = false)
        {
            //var user = GetRepository<TbUser>().Query(u => u.Pwd == pwd && u.UserTel == username).FirstOrDefault();
            var user = new MLD.Entity.TbUser()
            {
                Name = "Admin",
                UserTel = username
            };
            if (username != "admin" || pwd != "admin1")
            {
                return AjaxMsg("用户名密码错误", Library.AjaxModel.AjaxModel.State.Error, null);
            }
            SetCookie(UserCache.COOKIE,username);
            SetSession(UserCache.COOKIE,user);
            return AjaxMsg("登陆成功", Library.AjaxModel.AjaxModel.State.Success, null);
        }

        /// <summary>
        /// 为用户设置session
        /// </summary>
        /// <param name="key">session key</param>
        /// <param name="value">session value</param>
        public void SetSession(string key, object value)
        {
            HttpContext.Current.Session.Add(key, value);
            HttpContext.Current.Session.Timeout = 60;
        }

        /// <summary>
        /// 为用户设置cookie
        /// </summary>
        /// <param name="key">cookie key</param>
        /// <param name="value">cookie value</param>
        public void SetCookie(string key, string value)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(key, value));
            HttpContext.Current.Session.Timeout = 60;
        }
    }
}
