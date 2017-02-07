using System;

namespace MLD.ViewModel
{
    /// <summary>
    /// 课程列表
    /// </summary>
    public class CourseList
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// 课程开课时间
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// 课程结束时间
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// 课程图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 还可以预约的人数
        /// </summary>
        public int PersonNum { get; set; }

        /// <summary>
        /// 课程地址
        /// </summary>
        public string Addr { get; set; }
    }
}
