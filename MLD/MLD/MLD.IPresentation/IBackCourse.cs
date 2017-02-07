using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MLD.IPresentation
{
    public interface IBackCourse
    {
        /// <summary>
        /// 获取课程列表
        /// </summary>
        /// <param name="count">总数</param>
        /// <param name="index">开始的下标</param>
        /// <param name="lenght">数据的数量</param>
        /// <returns>课程列表</returns>
        IList<MLD.Entity.TbGroupCourse> Get(out int count,int index,int lenght);

        /// <summary>
        /// 根据课程获取课程的详细信息
        /// </summary>
        /// <param name="cId">课程编号</param>
        /// <returns>课程详细信息</returns>
        MLD.Entity.TbGroupCourse Get(int cId);

        /// <summary>
        /// 新增课程
        /// </summary>
        /// <param name="course">课程对象</param>
        /// <param name="img">课程图片</param>
        /// <returns>处理状态</returns>
        bool Add(MLD.Entity.TbGroupCourse course, HttpPostedFileBase img);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="course">修改</param>
        /// <param name="img">图片</param>
        /// <returns>状态</returns>
        bool Edit(MLD.Entity.TbGroupCourse course, HttpPostedFileBase img);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">删除的编号</param>
        void Delete(int id);

        /// <summary>
        /// 获取课程预约
        /// </summary>
        /// <param name="count">总数</param>
        /// <param name="index">开始的下标</param>
        /// <param name="lenght">数据的数量</param>
        /// <returns>预约列表</returns>
        IList<MLD.ViewModel.Back.Course> GetAppointment(out int count, int index, int lenght);

        /// <summary>
        /// 根据课程ID获取预约用户列表
        /// </summary>
        /// <param name="cId">课程ID</param>
        /// <returns>预约用户</returns>
        IList<MLD.ViewModel.Back.User> GetAppointmentUser(int cId);
    }
}
