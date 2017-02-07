using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MLD.IPresentation;
using MLD.Library.Constant;

namespace MVC.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据日期获取日期的课程
        /// </summary>
        [HttpGet]
        public ActionResult GetCourses(DateTime date)
        {
            IList<MLD.ViewModel.CourseList> course = base.Course.GetCourseAtDate(date);
            return View(course);
        }

        /// <summary>
        /// 获取预约用户的预约课程
        /// </summary>
        /// <param name="mobileNum"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserCourse(string mobileNum)
        {
            MLD.ViewModel.UserCourse userCourse = base.Course.GetCourseAtMobileNum(mobileNum);
            if (userCourse == null)
                return Content("false");
            return View(userCourse);
        }

        /// <summary>
        /// 取消预约课程
        /// </summary>
        [HttpPost]
        public ActionResult CancelCourse(int courseId, string mobileNum)
        {
            int state = (int)base.Course.CancelReservationCourse(mobileNum, courseId);
            return Content(state.ToString());
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OutLogin()
        {
            return View();
        }

        /// <summary>
        /// 课程详细
        /// </summary>
        [HttpGet]
        public ActionResult Info(int id)
        {
            MLD.ViewModel.CourseInfo model = base.Course.GetCourseInfo(id);
            
            return View(model);
        }

        [HttpPost]
        public ActionResult YuYue(string mobile, int personNum,int grpCourseId)
        {
            string state = base.Course.ReservationCourse(mobile, null, personNum, grpCourseId).GetEnumName();
            return Content(state);
        }
    }
}
