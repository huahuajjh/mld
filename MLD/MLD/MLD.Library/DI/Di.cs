using System;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using MLD.Library.SerializeHelper;

namespace MLD.Library.DI
{
    /// <summary>
    /// description:依赖注入框架 | dependency inject framework
    /// author:jjh
    /// date:2015-07-25 14:40
    /// last modify date:2015-07-25 14:40
    /// </summary>
    public static class Di
    {
        /// <summary>
        /// 根据配置文件中的key获取实例对象 | get instance object according to key field in which config file
        /// </summary>
        /// <typeparam name="T">要获取的实例类型参数 | type parameter which user want to get</typeparam>
        /// <param name="key">配置文件key | config file's key</param>
        /// <param name="isSingleton">是否要获取单例 | if user want to get singleton</param>
        /// <returns>T | 泛型实例</returns>
        public static T GetInstance<T>(string key,bool isSingleton = false)
        {
            //获取配置文件key对象
            ConnectionStr connObj = ConfigFileHelper.GetConnStr(key);

            //从给定的程序集名称反射对象
            T obj = default(T);

            try
            {
                if (!isSingleton)
                {
                    obj = (T) Assembly.Load(connObj.ProvideName).CreateInstance(connObj.ConnectionString);
                    //根据给定的程序集名称反射，并返回实例化的对象
                    return obj;
                }
                if (null == CallContext.GetData(key))   //检查CallContext中是否已经存在对应key
                {
                    obj = (T)Assembly.Load(connObj.ProvideName).CreateInstance(connObj.ConnectionString);
                    //如果不存在，说明是第一次请求创建对象,该对象在线程级别提供数据共享
                    CallContext.SetData(key, obj);
                }

                return (T)CallContext.GetData(key);

            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception(ex.Message);
            }

        }
    }
}
