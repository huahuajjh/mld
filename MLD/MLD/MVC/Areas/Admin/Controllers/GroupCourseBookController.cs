using System.Web.Mvc;
using MVC.Controllers;

namespace MVC.Areas.Admin.Controllers
{
    public class GroupCourseBookController : BaseController
    {
        /// <summary>
        /// 团课预约首页
        /// </summary>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回数据
        /// </summary>
        [HttpPost]
        public ActionResult Index(int iDisplayStart, int iDisplayLength, string sEcho)
        {
            int count;
            var data = base.BackCourse.GetAppointment(out count, iDisplayStart, iDisplayLength);
            return Json(new Models.TableAjaxOut()
            {
                aaData = data,
                iTotalDisplayRecords = count,
                iTotalRecords = count,
                sEcho = sEcho
            });
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var model = base.BackCourse.GetAppointmentUser(id);
            return View(model);
        }
    }
}
