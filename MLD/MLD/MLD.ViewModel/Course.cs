using System;
using MLD.ViewModel.State;

namespace MLD.ViewModel
{
    /// <summary>
    /// 课程信息
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 课程开课时间
        /// </summary>
        public DateTime CourseDate { get; set; }

        /// <summary>
        /// 课程开课时间
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// 课程结束时间
        /// </summary>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// 课程地点
        /// </summary>
        public string CourseAddr { get; set; }

        /// <summary>
        /// 预约状态
        /// </summary>
        public ReservationState ReservationState { get; set; }

        /// <summary>
        /// 课程缩略图
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId { get; set; }
    }
}
