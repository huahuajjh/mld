using System.ComponentModel;

namespace MLD.ViewModel.State
{
    /// <summary>
    /// 课程状态
    /// </summary>
    public enum CourseState
    {
        /// <summary>
        /// 预约未满
        /// </summary>
        [Description("可以预约")]
        ReservationNotFull = 0,

        /// <summary>
        /// 预约已满
        /// </summary>
        [Description("不可以预约")]
        ReservationFull = 1
    }
}
