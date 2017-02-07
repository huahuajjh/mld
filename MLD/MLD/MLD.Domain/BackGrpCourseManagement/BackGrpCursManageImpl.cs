using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using MLD.Entity;
using MLD.IPresentation;
using MLD.Library.Constant;
using MLD.Library.FileHelper;
using MLD.Library.SerializeHelper;
using MLD.ViewModel.Back;

namespace MLD.Domain.BackGrpCourseManagement
{
    public class BackGrpCursManageImpl : Base, IBackCourse
    {
        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <param name="count">总数</param>
        /// <param name="index">开始的下标</param>
        /// <param name="lenght">数据的数量</param>
        /// <returns>课程列表</returns>
        public IList<TbGroupCourse> Get(out int count, int index, int lenght)
        {
            IList<TbGroupCourse> list = null;
            try
            {
                list = GetRepository<TbGroupCourse>().QueryByPage<int>(null, c => c.Id > 0 && c.Del == false, a => a.Id, lenght, index, out count).ToList();
                return list;
            }
            catch (Exception)
            {
                count = 0;
                return list;
            }
        }

        /// <summary>
        /// 根据课程比编号获取课程的详细信息
        /// </summary>
        /// <param name="cId">课程编号</param>
        /// <returns>课程详细信息</returns>
        public TbGroupCourse Get(int cId)
        {
            var grpCourse = GetRepository<TbGroupCourse>().Query(c => c.Id == cId && c.Del == false).FirstOrDefault();
            if (null == grpCourse)
            {
                return null;
            }

            grpCourse.Img = ConfigFileHelper.GetAppSettingValue(DiKey.IMGDIR) + grpCourse.Img;
            return grpCourse;

        }

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="course">课程对象</param>
        /// <param name="img">课程图片</param>
        /// <returns>处理状态</returns>
        public bool Add(TbGroupCourse course, HttpPostedFileBase img)
        {
            try
            {
                if (null != img)
                {
                    //保存图片
                    string name = FileHelper.SaveFile(img, 150, 150);
                    course.Img = name;
                }
                course.BookHowManyPerosonNum = course.MaxPersons;
                string startDate = course.StartTime.ToString("d");
                string startTime = course.StartTime.ToString().Replace(startDate,course.CourseDate.ToString("d"));
                string endTime = course.EndTime.ToString().Replace(course.EndTime.ToString("d"), course.CourseDate.ToString("d"));
                course.StartTime = DateTime.Parse(startTime);
                course.EndTime = DateTime.Parse(endTime);
                
                GetRepository<TbGroupCourse>().Add(course);
                Repository.SaveChange();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="course">修改</param>
        /// <param name="img">图片</param>
        /// <returns>状态</returns>
        public bool Edit(TbGroupCourse course, HttpPostedFileBase img)
        {
            //查询出要修改的课程表对象
            var grpCourse = GetRepository<TbGroupCourse>().Query(course.Id);
            if (null == grpCourse) { return false; }

            string startDate = course.StartTime.ToString("d");
            string startTime = course.StartTime.ToString().Replace(startDate, course.CourseDate.ToString("d"));
            string endTime = course.EndTime.ToString().Replace(course.EndTime.ToString("d"), course.CourseDate.ToString("d"));
            course.StartTime = DateTime.Parse(startTime);
            course.EndTime = DateTime.Parse(endTime);

            try
            {
                //保存图片,并修改资料
                grpCourse.EndTime = course.EndTime;
                grpCourse.Addr = course.Addr;
                grpCourse.CourseDate = course.CourseDate;
                grpCourse.Descrp = course.Descrp;
                grpCourse.EndTime = course.EndTime;
                grpCourse.MaxPersons = course.MaxPersons;
                grpCourse.MaxPersonsOnce = course.MaxPersonsOnce;
                grpCourse.Name = course.Name;
                grpCourse.StartTime = course.StartTime;
                grpCourse.EndTime = course.EndTime;

                if (null != img)
                {
                    string name = FileHelper.SaveFile(img, 150, 150);
                    grpCourse.Img = name;
                }

                Repository.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除的编号</param>
        public void Delete(int id)
        {
            //根据id获取课程表对象
            var grpCourse = GetRepository<TbGroupCourse>().Query(id);
            if (null == grpCourse) { return; }

            //删除团课课程表
            grpCourse.Del = true;
            Repository.SaveChange();
        }

        /// <summary>
        /// 获取课程预约
        /// </summary>
        /// <param name="count">总数</param>
        /// <param name="index">开始的下标</param>
        /// <param name="lenght">数据的数量</param>
        /// <returns>预约列表</returns>
        public IList<ViewModel.Back.Course> GetAppointment(out int count, int index, int lenght)
        {
            //获取预约课程记录
            IList<ViewModel.Back.Course> list = new List<ViewModel.Back.Course>();

            var recordList = GetRepository<TbGroupCourseBookRecord>()
                .QueryByPage<int>(null, r => r.Del == false, c => c.GrpCrsId, lenght, index, out count);//.GroupBy(g=>g.GrpCrsId);
            //IList<TbGroupCourse> grpCourseList = new List<TbGroupCourse>();
            var ids = new List<int>();

            //根据查询到的记录集合查询团课课程表集合
            foreach (var tbGroupCourseBookRecord in recordList)
            {
                if (ids.Contains(tbGroupCourseBookRecord.GrpCrsId)){continue;}
                ids.Add(tbGroupCourseBookRecord.GrpCrsId);
                var grpCourse = GetRepository<TbGroupCourse>().Query(c => c.Id == tbGroupCourseBookRecord.GrpCrsId && c.Del == false).FirstOrDefault();

                if (null == grpCourse) { continue; }
                list.Add(grpCourse.ToBackCourse());
            }
            return list;

        }

        /// <summary>
        /// 根据课程ID获取预约用户列表
        /// </summary>
        /// <param name="cId">团课课程ID</param>
        /// <returns>预约用户</returns>
        public IList<User> GetAppointmentUser(int cId)
        {
            IList<ViewModel.Back.User> userList = new List<ViewModel.Back.User>();
            IList<TbUser> tbUserList = new List<TbUser>();

            //根据课程id获取用户
            var recordList = GetRepository<TbGroupCourseBookRecord>().Query(r => r.GrpCrsId == cId && r.Del == false);
            foreach (var tbGroupCourseBookRecord in recordList)
            {
                var user = GetRepository<TbUser>().Query(u => u.Id == tbGroupCourseBookRecord.UserId && u.Del == false).FirstOrDefault();
                if (null == user) { break; }
                var ur = user.ToBackUser();
                userList.Add(ur);
            }

            return userList;
        }
    }
}
