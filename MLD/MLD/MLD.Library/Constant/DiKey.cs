namespace MLD.Library.Constant
{
    /// <summary>
    /// description:依赖框架类使用的静态key | static key field which is used by di framework
    /// author:jjh
    /// date:2015-07-25 14:50
    /// last modify date:2015-07-25 14:50
    /// </summary>
    public sealed class DiKey
    {
        /// <summary>
        /// 配置文件中数据服务类的key | data service's key in config file
        /// </summary>
        public static readonly string BLLKEY = "Service";

        /// <summary>
        /// 配置文件中数据访问类的key | data access key in config file
        /// </summary>
        public static readonly string DALKEY = "Repository";

        /// <summary>
        /// 数据库上下文 | db context
        /// </summary>
        public static readonly string DBCONTEXT = "DbContext";

        /// <summary>
        /// 图像地址
        /// </summary>
        public static readonly string IMGDIR = "ImgDir";

        /// <summary>
        /// 日志key
        /// </summary>
        public static readonly string LOGGER = "Logger";

    }
}
