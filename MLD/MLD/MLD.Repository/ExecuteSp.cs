using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MLD.IRepository;

namespace MLD.Repository
{
    /// <summary>
    /// 该类负责执行存储过程
    /// </summary>
    public class ExecuteSp : Base, IExecuteSp
    {
        private static ExecuteSp _sp;

        private ExecuteSp()
        {
            
        }

        public static ExecuteSp GetInstance()
        {
            return _sp ?? (_sp = new ExecuteSp());
        }

        /// <summary>
        /// 执行存储过程，该存储过程不返回数据集
        /// </summary>
        /// <param name="spName">存储过程名称</param>
        /// <param name="params">存储过程参数</param>
        /// <returns>存储过程执行代码</returns>
        public int DoExecuteSp(string spName, params SqlParameter[] @params)
        {
            if (@params.Length > 0)
            {
                spName = spName + " ";
                string[] strs = @params.Select(d =>
                {
                    if (d.Direction == ParameterDirection.Output)
                        return d.ParameterName + " output";
                    return d.ParameterName;

                }).ToArray();
                spName = spName + string.Join(",", strs);
            }
            return DbContext.Database.ExecuteSqlCommand(spName, @params);

        }

        /// <summary>
        /// 执行存储过程，该存储过程返回数据集
        /// </summary>
        /// <typeparam name="T">实体类型参数，该类型对应存储过程返回的数据集实体</typeparam>
        /// <param name="spName">存储过程名称</param>
        /// <param name="params">存储过程参数</param>
        /// <returns>返回的实体集合</returns>
        public IEnumerable<T> DoExecuteSp<T>(string spName, params SqlParameter[] @params)
        {
            if (@params.Length > 0)
            {
                spName = spName + " ";
                string[] strs = @params.Select(d =>
                {
                    if (d.Direction == ParameterDirection.Output)
                        return d.ParameterName + " output";
                    return d.ParameterName;

                }).ToArray();
                spName = spName + string.Join(",", strs);
            }
            return DbContext.Database.SqlQuery<T>(spName, @params);
        }

        public IEnumerable<T> DoExecuteSpOld<T>(string spName, params object[] @params)
        {
            return DbContext.Database.SqlQuery<T>(spName, @params);
        }

        /// <summary>
        /// 执行存储过程，该存储过程返回元素集合
        /// </summary>
        /// <typeparam name="T">要返回的存储过程的元素实体</typeparam>
        /// <param name="spName">存储过程名称</param>
        /// <param name="params">存储过程参数</param>
        /// <returns>存储过程返回元素集合</returns>
        public IEnumerable<T> DoExecuteSp<T>(string spName, params object[] @params)
        {
            return DbContext.Database.SqlQuery<T>(spName, @params);
        }
    }
}
