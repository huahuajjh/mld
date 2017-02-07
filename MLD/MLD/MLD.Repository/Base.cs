using MLD.IRepository;
using MLD.Library.Constant;
using MLD.Library.DI;
using MLD.Data;

namespace MLD.Repository
{
    /// <summary>
    /// 仓储实现基类，该类主要提供由外部注入的db上下文
    /// </summary>
    public abstract class Base
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public static IDataContext DbContext
        {
            get
            {
                return Di.GetInstance<IDataContext>(DiKey.DBCONTEXT, true);
            }
        }

        /// <summary>
        /// 静态构造函数，通过DI组件初始化db上下文
        /// </summary>
        static Base()
        {
            Di.GetInstance<IDataContext>(DiKey.DBCONTEXT, true);
        }
    }
}
