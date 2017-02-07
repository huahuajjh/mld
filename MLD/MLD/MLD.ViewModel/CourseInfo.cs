using System;

namespace MLD.ViewModel
{
    /// <summary>
    /// 课程详细信息
    /// </summary>
    public class CourseInfo
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 课程图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 课程开课时间
        /// </summary>
        public DateTime CourseDate { get; set; }

        /// <summary>
        /// 课程开始时间
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// 课程结束时间
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// 课程还可预约的人数
        /// </summary>
        public int PersonNum { get; set; }

        /// <summary>
        /// 课程地点
        /// </summary>
        public string Addr { get; set; }

        /// <summary>
        /// 课程介绍信息
        /// </summary>
        public string Introduce { get; set; }

        /// <summary>
        /// 课程状态
        /// </summary>
        public State.CourseState CourseState { get; set; }
    }
}
