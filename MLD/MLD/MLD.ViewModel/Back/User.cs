namespace MLD.ViewModel.Back
{
    /// <summary>
    /// 预约用户列表
    /// </summary>
    public class User
    {
        /// <summary>
        /// 联系号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 预约用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户预约的状态
        /// </summary>
        public State.ReservationState ReservationState { get; set; }
    }
}
