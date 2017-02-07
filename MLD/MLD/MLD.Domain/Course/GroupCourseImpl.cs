using System;
using System.Collections.Generic;
using System.Linq;
using MLD.Entity;
using MLD.IPresentation;
using MLD.Library.Helper;
using MLD.ViewModel;
using MLD.ViewModel.State;

namespace MLD.Domain.Course
{
    public class GroupCourseImpl : Base, ICourse
    {
        public IList<CourseList> GetCourseAtDate(DateTime date)
        {
            IList<CourseList> list = new List<CourseList>();
            try
            {
                IList<TbGroupCourse> courses = GetRepository<TbGroupCourse>().Query(c => c.CourseDate == date && c.Del == false).ToList();
                foreach (var tbGroupCourse in courses)
                {
                    list.Add(tbGroupCourse.ToCourseList());
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserCourse GetCourseAtMobileNum(string mobileNum)
        {
            //课表集合
            IList<ViewModel.Course> courses = new List<ViewModel.Course>();

            try
            {
                //根据电话查询出用户id
                var user = GetRepository<TbUser>().Query(u => u.UserTel == mobileNum && u.Del == false).FirstOrDefault();
                if (null == user)
                {
                    return null;}

                //用户ViewMoel
                var userCourse = new UserCourse()
                {
                    Name = user.Name,
                    UserTel = user.UserTel
                };

                //根据用户id查询用户团课预约记录(目前只返回一条，有可能一个而用户预约了多个课程)
                var records = GetRepository<TbGroupCourseBookRecord>().Query(r => r.UserId == user.Id && r.Del == false).ToList();

                //根据预约记录查询出所有相对于的课程集合
                foreach (var tbGroupCourseBookRecord in records)
                {
                    //根据团课课程表id获取团课课表对象
                    var grpCourse = GetRepository<TbGroupCourse>().Query(g => g.Id == tbGroupCourseBookRecord.GrpCrsId && g.Del == false).FirstOrDefault();
                    if (null == grpCourse)
                    {
                        break;
                    }

                    var course = grpCourse.ToCourse();
                    switch (tbGroupCourseBookRecord.BookState)
                    {
                        case 0:
                            course.ReservationState = ReservationState.WaitClasses;
                            break;

                        case 1:
                            course.ReservationState = ReservationState.UpClasses;
                            break;

                        case 2:
                            course.ReservationState = ReservationState.CancelClasses;
                            break;
                    }

                    courses.Add(course);
                }
                userCourse.Courses = courses;
                return userCourse;
            }
            catch (Exception)
            {
                return null;
            }


        }

        public CourseInfo GetCourseInfo(int id)
        {
            try
            {
                //根据课程表id获取课程表对象
                var grpCourse = GetRepository<TbGroupCourse>().Query(id);
                return grpCourse.ToCourseInfo();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public ReservationCourseState ReservationCourse(string mobile, string name, int personNum, int grpCourseId)
        {
            //根据电话查询用户对象
            var user = GetRepository<TbUser>().Query(u => u.UserTel == mobile && u.Del == false).FirstOrDefault();
            if (null == user) { return ReservationCourseState.UserNotExist; }

            //根据课程id查询课程对象
            var grpCourse = GetRepository<TbGroupCourse>().Query(c => c.Id == grpCourseId && c.Del == false).FirstOrDefault();
            if (null == grpCourse) { return ReservationCourseState.NotExist; }
            
            //查看当前用户是否已经预约过该课程了
            var record = GetRepository<TbGroupCourseBookRecord>().Query(r => r.UserId == user.Id && r.GrpCrsId == grpCourseId && r.Del == false).FirstOrDefault();
            if (null != record) { return ReservationCourseState.Repeat; }

            //检测是否可以预约
            var bookResult = grpCourse.CanBook();
            if (bookResult == ReservationCourseState.Success)
            {
                //用户是否有足够的课时进行预约
                var state = user.CanAppointment();
                if (state != ReservationCourseState.Success)
                {
                    return state;
                }

                var grpRecord = new TbGroupCourseBookRecord()
                {
                    Del = false,
                    GrpCrsId = grpCourseId,
                    UserId = user.Id,
                    BookState = (int)ReservationCourseState.Success,
                    BookPersonNum = personNum,
                    Id = 0
                };
                try
                {
                    GetRepository<TbGroupCourseBookRecord>().Add(grpRecord);
                    //客户消耗一节课
                    user.Cost1Course();
                    //该课程表预约用户增加一位
                    grpCourse.AppointmentPersonNum += 1;
                    //课程表的还可预约人数减1
                    grpCourse.BookHowManyPerosonNum -= 1;
                    Repository.SaveChange();
                    return bookResult;
                }
                catch (Exception)
                {
                    return bookResult;
                }
            }

            return bookResult;
        }

        public CancelCourseState CancelReservationCourse(string mobile, int courseId)
        {
            //根据用户电话查找用户对象
            var user = GetRepository<TbUser>().Query(u=>u.UserTel == mobile && u.Del == false).FirstOrDefault();
            if (null == user){return CancelCourseState.UserNotExists;}

            //根据用户id和课程id查询出预约记录表对象
            var grpCourseRecord = GetRepository<TbGroupCourseBookRecord>().Query(r=>r.UserId == user.Id && r.GrpCrsId == courseId && r.Del == false).FirstOrDefault();
            if (null == grpCourseRecord){return CancelCourseState.NotExist;}

            //查询课程表对象
            var grpCourse = GetRepository<TbGroupCourse>().Query(g => g.Del == false && g.Id == grpCourseRecord.GrpCrsId).FirstOrDefault();
            if (null == grpCourse){return CancelCourseState.CancelFailure;}

            //是否可以取消预约
            var rs = grpCourse.CanCancelBook();
            if (rs == CancelCourseState.CancelSuccess)
            {
                grpCourseRecord.Del = true;
                //课程表中的可预约数加1,已经预约人数减1
                grpCourse.BookHowManyPerosonNum += 1;
                grpCourse.AppointmentPersonNum -= 1;
                //该用户的课程数加1，课程消耗数减1
                user.CostClassNum -= 1;

                Repository.SaveChange();
                return rs;
            }
            return rs;
        }
    }
}
