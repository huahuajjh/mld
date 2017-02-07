using MLD.IRepository;

namespace MLD.Repository
{
    /// <summary>
    /// 该类负责创建具体实体对象
    /// </summary>
    /// <typeparam name="T">实体类型参数</typeparam>
    public class RepositoryFactory<T> : IRepositoryFactory<T> where T : class
    {
        /// <summary>
        /// 返回实体对象
        /// </summary>
        public IBaseRepository<T> Entity
        {
            get
            {
                return new BaseRepository<T>();
            }
        }
    }
}
