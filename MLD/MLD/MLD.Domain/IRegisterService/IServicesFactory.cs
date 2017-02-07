namespace MLD.Domain.IRegisterService
{
    /// <summary>
    /// 应用层工厂接口，生产业务对象的策略
    /// </summary>
    public interface IServicesFactory<T> where T : class
    {
        /// <summary>
        /// 获取服务实现基类，该方法一般提供公共服务类
        /// </summary>
        IBaseServices<T> Service  {get; }
        
        /// <summary>
        /// 根据服务key获取服务
        /// </summary>
        /// <param name="serviceKey">服务key</param>
        /// <returns>服务对象接口</returns>
        T GetService(string serviceKey);
    }
}
