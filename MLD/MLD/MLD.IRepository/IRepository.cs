namespace MLD.IRepository
{
    /// <summary>
    /// 此接口提供各实体的工厂以及统一的保存方式，存储过程
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// 获取仓储工厂，该工厂产生具体实体对象
        /// </summary>
        /// <typeparam name="T">类型参数，该参数代表要获取的实体类型</typeparam>
        /// <returns>返回代表该实体工厂的对象</returns>
        IRepositoryFactory<T> GetReposirotyFactory<T>() where T : class;

        /// <summary>
        /// 获取专门执行存储过程的实例
        /// </summary>
        /// <returns>存储过程执行对象</returns>
        IExecuteSp GetSpInstance();

        /// <summary>
        /// 持久化保存，新增，删除，修改都需要调用此方法来持久化数据
        /// </summary>
        int SaveChange();
    }
}
