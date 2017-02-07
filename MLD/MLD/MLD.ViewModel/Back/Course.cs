namespace MLD.ViewModel.Back
{
    public class Course
    {
        /// <summary>
        /// 团课编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 课程开课日期
        /// </summary>
        public string CourseDate { get; set; }

        /// <summary>
        /// 开始时间和结束时间的时间段
        /// 格式[16:40-18:30]
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 已经预约的人数
        /// </summary>
        public int PersonNum { get; set; }
    }
}
