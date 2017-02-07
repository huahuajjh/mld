namespace MLD.IRepository
{
    /// <summary>
    /// 实体生产工厂，专用于生产实体
    /// </summary>
    /// <typeparam name="T">类型参数，该参数代表每个实体类型</typeparam>
    public interface IRepositoryFactory<T> where T : class
    {
        /// <summary>
        /// 该属性提供具体的实体对象
        /// </summary>
        IBaseRepository<T> Entity { get;}
    }
}
