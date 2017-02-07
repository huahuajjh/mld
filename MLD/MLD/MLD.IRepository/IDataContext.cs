using System;
using System.Data.Entity;
using System.Linq;

namespace MLD.IRepository
{
    /// <summary>
    /// description:数据库上下文接口 | db context interface
    /// author:jjh
    /// date:2015-07-25 15:11
    /// last modify date:2015-07-25 15:11
    /// </summary>
    public interface IDataContext : IDisposable
    {
        Guid InstanceId { get; }

        /// <summary>
        /// 数据库包装对象 | db warpper object
        /// </summary>
        Database Database { get; }

        /// <summary>
        /// 数据库表对象 | db tbale warpper object
        /// </summary>
        /// <typeparam name="T">泛型参数 | genic parameter</typeparam>
        /// <returns></returns>
        DbSet<T> Set<T>() where T : class;

        /// <summary>
        /// 统一保存修改方法 | unity save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 执行存储过程，并且返回指定的类型 | Execute Stored Procedure which returns specific Type
        /// </summary>
        /// <typeparam name="T">泛型参数 | genic parameter</typeparam>
        /// <param name="query">存储过程语句 | Stored Procedure statement</param>
        /// <param name="parameters">存储过程参数 | Stored Procedure parameters</param>
        /// <returns>泛型参数类型 | genic type</returns>
        IQueryable<T> ExecuteStoredProcedure<T>(string query,params object[] parameters);

    }
}
