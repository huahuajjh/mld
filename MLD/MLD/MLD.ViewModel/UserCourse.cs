using System.Collections.Generic;

namespace MLD.ViewModel
{
    /// <summary>
    /// 用户课程
    /// </summary>
    public class UserCourse
    {
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public string UserTel { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 课程列表
        /// </summary>
        public IList<Course> Courses { get; set; }
    }
}
