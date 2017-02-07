namespace MLD.Library.AjaxModel
{
    /// <summary>
    /// 此类用于格式化Ajax请求的模型类
    /// </summary>
    public class AjaxModel
    {
        /// <summary>
        /// 回显给客户端的消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 返回给客户端的数据
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 服务器处理的状态
        /// </summary>
        public State Status { get; set; }

        /// <summary>
        /// 状态值
        /// </summary>
        public enum State
        {
            Success = 0,    //处理成功
            Fail = 1,   // 处理失败
            ServerError = 2,    //服务器错误
            Error = 3   //错误
        }
    }
}
