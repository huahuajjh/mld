using System.Linq;
using System.Web.Mvc;
using MLD.Domain.IRegisterService;
using MLD.IPresentation;
using MLD.Library.AjaxModel;
using MLD.Library.Constant;
using MLD.Library.DI;
using MLD.Library.SerializeHelper;
using MLD.Library.Helper;

namespace MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Services对象
        /// </summary>
        private static IServices Service { get; set; }

        protected ICourse Course {
            get
            {
                return GetService<ICourse>(ServiceName.GROUPCOURSE);
            }
        }

        protected IBackCourse BackCourse
        {
            get
            {
                return GetService<IBackCourse>(ServiceName.GRPCOURSEMANAGEMEMT);
            }
        }

        protected IUser BackUser
        {
            get
            {
                return GetService<IUser>(ServiceName.USERMANAGEMENT);
            }
        }

        /// <summary>
        /// 初始化Services
        /// </summary>
        static BaseController()
        {
            Service = Di.GetInstance<IServices>(DiKey.BLLKEY, true);
        }

        protected static T GetService<T>(string serviceKey) where T : class
        {
            return Service.GetServicesFactory<T>().GetService(serviceKey);
        }

        protected bool Validate(params string[] objs)
        {
            return objs.All(o=>!o.IsNull());
        }

        /// <summary>
        /// 返回给前端的消息
        /// </summary>
        /// <param name="info">返回给前端的消息</param>
        /// <param name="contentType">ContentType MIME类型，默认为'text/html'</param>
        /// <returns></returns>
        public ActionResult AjaxMessage(string msg, AjaxModel.State state, object data, string contentType = "application/json")
        {
            var info = new AjaxModel()
            {
                Msg = msg,
                Status = state,
                Data = data
            };

            return new ContentResult()
            {
                Content = SerializeHelper.Serialize(info),
                ContentType = contentType
            };
        }

        /// <summary>
        /// 返回给前端的消息
        /// </summary>
        /// <returns></returns>
        public ActionResult AjaxMessage(string info)
        {
            return new ContentResult()
            {
                Content = info,
                ContentType = "application/json"
            };
        }

        /// <summary>
        /// 返回Ajax消息封装
        /// </summary>
        /// <param name="ajaxMsg">要反馈给客户端的消息</param>
        /// <param name="state">返回状态</param>
        /// <param name="data">返回给客户端的数据</param>
        /// <returns></returns>
        public string AjaxMsg(string ajaxMsg, AjaxModel.State state, object data)
        {
            return SerializeHelper.Serialize(new AjaxModel()
            {
                Msg = ajaxMsg,
                Status = state,
                Data = data
            });
        }
    }
}
