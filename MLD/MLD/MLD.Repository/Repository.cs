using MLD.IRepository;
using MLD.Library.Constant;
using MLD.Library.DI;

namespace MLD.Repository
{
    /// <summary>
    /// 仓储实现类，提供实体工厂和存储过程执行
    /// </summary>
    public class Repository:IRepository.IRepository
    {
        /// <summary>
        /// 实体工厂
        /// </summary>
        /// <typeparam name="T">实体类型参数</typeparam>
        /// <returns>实体工厂</returns>
        public IRepositoryFactory<T> GetReposirotyFactory<T>() where T : class
        {
            return new RepositoryFactory<T>();
        }

        /// <summary>
        /// 存储过程
        /// </summary>
        /// <returns>存储过程</returns>
        public IExecuteSp GetSpInstance()
        {
            return ExecuteSp.GetInstance();
        }

        /// <summary>
        /// 持久化保存，新增，删除，修改都需要调用此方法来持久化数据
        /// </summary>
        public int SaveChange()
        {
            return Di.GetInstance<Data.MLDDbContext>(DiKey.DBCONTEXT,true).SaveChanges();
        }
    }
}
