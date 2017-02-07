using System;
using System.Configuration;

namespace MLD.Library.SerializeHelper
{
    /// <summary>
    /// description:config文件帮助类 | config file helper class
    /// author:jjh
    /// date:2015-07-25 18:29
    /// last modify date:2015-07-25 18:29
    /// </summary>
    public static class ConfigFileHelper
    {
        /// <summary>
        /// 返回appsetting指定key的value值
        /// </summary>
        /// <param name="appKey">指定的appKey</param>
        /// <returns>对应的value</returns>
        public static string GetAppSettingValue(string appKey)
        {
            return ConfigurationManager.AppSettings[appKey];
        }

        /// <summary>
        /// 获取配置文件的connectionString
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>connectionString包装值对象</returns>
        public static ConnectionStr GetConnStr(string key)
        {
            return new ConnectionStr()
            {
                ProvideName = ConfigurationManager.ConnectionStrings[key].ProviderName,
                ConnectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString
            };
        }

    }

    /// <summary>
    ///  该结构体表示配置文件中的ConnectionString节点中的一条配置项，比如
    ///  <connectionStrings><add name="Repository" providerName="Ims.Repository" connectionString="Ims.Repository.Repository"/></connectionStrings>
    ///  中间的add项就是该结构体
    /// </summary>
    public struct ConnectionStr
    {
        //一个配置项的ProvideName
        public string ProvideName { get; set; }

        //一个配置项的ConnectionString
        public string ConnectionString { get; set; }
    }
}
