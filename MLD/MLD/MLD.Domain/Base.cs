using MLD.IRepository;
using MLD.Library.AjaxModel;
using MLD.Library.Constant;
using MLD.Library.DI;
using MLD.Library.SerializeHelper;

namespace MLD.Domain
{
    /// <summary>
    /// 该类提供仓储入口点
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// Repository对象
        /// </summary>
        protected static IRepository.IRepository Repository { get; set; }

        /// <summary>
        /// 初始化仓储
        /// </summary>
        static Base()
        {
            Repository = Di.GetInstance<IRepository.IRepository>(DiKey.DALKEY, true);
        }

        /// <summary>
        /// 获取仓储实体
        /// </summary>
        /// <typeparam name="T">数据实体类型参数</typeparam>
        /// <returns>仓储实体</returns>
        protected static IBaseRepository<T> GetRepository<T>() where T : class
        {
            return Repository.GetReposirotyFactory<T>().Entity;
        }

        /// <summary>
        /// 反馈消息
        /// </summary>
        /// <param name="msg">要反馈给客户端的消息</param>
        /// <param name="state">消息状态</param>
        /// <param name="data">反馈给客户端的数据</param>
        /// <returns></returns>
        protected string AjaxMsg(string msg, AjaxModel.State state, object data)
        {
            return SerializeHelper.Serialize(new AjaxModel()
            {
                Msg = msg,
                Status = state,
                Data = data
            });
        }
    }
}
