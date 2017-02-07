namespace MLD.ViewModel.State
{
    /// <summary>
    /// 取消预约课程状态
    /// </summary>
    public enum CancelCourseState
    {
        /// <summary>
        /// 预约不存在
        /// </summary>
        NotExist = 0,

        /// <summary>
        /// 取消预约课程失败
        /// </summary>
        CancelFailure = 1,

        /// <summary>
        /// 取消预约成功
        /// </summary>
        CancelSuccess = 2,

        /// <summary>
        /// 不在可以取消预约的时间范围
        /// </summary>
        NotTimeRange = 3,

        /// <summary>
        /// 该手机对应用户不存在
        /// </summary>
        UserNotExists = 4
    }
}
