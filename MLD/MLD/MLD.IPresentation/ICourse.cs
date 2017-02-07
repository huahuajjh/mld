using System;
using System.Collections.Generic;
using MLD.ViewModel;

namespace MLD.IPresentation
{
    /// <summary>
    /// 课程操作
    /// </summary>
    public interface ICourse
    {
        /// <summary>
        /// 根据指定日期获取课程
        /// </summary>
        /// <param name="date">指定日期</param>
        /// <returns>课程</returns>
        IList<CourseList> GetCourseAtDate(DateTime date);

        /// <summary>
        /// 根据指定手机号码，获取用户的预约课程
        /// </summary>
        /// <param name="mobileNum">手机号码</param>
        /// <returns></returns>
        ViewModel.UserCourse GetCourseAtMobileNum(string mobileNum);

        /// <summary>
        /// 根据指定的课程ID获取课程信息
        /// </summary>
        /// <param name="id">课程ID</param>
        /// <returns>课程详细信息</returns>
        ViewModel.CourseInfo GetCourseInfo(int id);

        /// <summary>
        /// 预约课程
        /// </summary>
        /// <param name="mobile">预约用户的手机号码</param>
        /// <param name="name">预约用户姓名</param>
        /// <param name="personNum">预约的人数</param>
        /// <param name="grpCourseId">要预约的团课id</param>
        /// <returns>预约的状态</returns>
        ViewModel.State.ReservationCourseState ReservationCourse(string mobile,string name,int personNum,int grpCourseId);

        /// <summary>
        /// 取消预约课程
        /// </summary>
        /// <param name="mobile">取消预约用户的手机号码</param>
        /// <param name="courseId">取消预约的课程编号</param>
        /// <returns>取消状态</returns>
        ViewModel.State.CancelCourseState CancelReservationCourse(string mobile,int courseId);
    }
}