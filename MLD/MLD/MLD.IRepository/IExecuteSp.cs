using System.Collections.Generic;
using System.Data.SqlClient;

namespace MLD.IRepository
{
    /// <summary>
    /// 执行存储过程接口
    /// </summary>
    public interface IExecuteSp
    {
        /// <summary>
        /// 执行存储过程，该存储过程不返回元素集合
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="params">存储过程参数</param>
        /// <returns></returns>
        int DoExecuteSp(string spName,params SqlParameter[] @params);

        /// <summary>
        /// 执行存储过程，该存储过程返回元素集合
        /// </summary>
        /// <typeparam name="T">要返回的存储过程的元素实体</typeparam>
        /// <param name="spName">存储过程名称</param>
        /// <param name="params">存储过程参数</param>
        /// <returns>存储过程返回元素集合</returns>
        IEnumerable<T> DoExecuteSp<T>(string spName, params SqlParameter[] @params);

        /// <summary>
        /// 执行存储过程，该存储过程返回元素集合
        /// </summary>
        /// <typeparam name="T">要返回的存储过程的元素实体</typeparam>
        /// <param name="spName">存储过程名称</param>
        /// <param name="params">存储过程参数</param>
        /// <returns>存储过程返回元素集合</returns>
        IEnumerable<T> DoExecuteSpOld<T>(string spName, params object[] @params);

    }
}
