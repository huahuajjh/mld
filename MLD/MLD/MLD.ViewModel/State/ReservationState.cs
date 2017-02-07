using System.ComponentModel;

namespace MLD.ViewModel.State
{
    /// <summary>
    /// 预约状态
    /// </summary>
    public enum ReservationState
    {
        /// <summary>
        /// 等待上课
        /// </summary>
        [Description("等待上课")]
        WaitClasses = 0,

        /// <summary>
        /// 已经上课
        /// </summary>
        [Description("已经上课")]
        UpClasses = 1,

        /// <summary>
        /// 取消预约
        /// </summary>
        [Description("取消预约")]
        CancelClasses = 2
    }
}
