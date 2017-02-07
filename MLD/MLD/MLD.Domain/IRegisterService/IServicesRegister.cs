namespace MLD.Domain.IRegisterService
{
    /// <summary>
    /// 服务注册器接口，用于定义注册器
    /// </summary>
    public interface IServicesRegister
    {
        /// <summary>
        /// 注册服务方法
        /// </summary>
        /// <param name="serviceKey">服务key,用于唯一标识服务，建议使用当前服务类的全限定名称</param>
        /// <param name="service">被注册的服务对象</param>
        void RegisteService(string serviceKey,object service);

        /// <summary>
        /// 根据serviceKey获取服务
        /// </summary>
        /// <param name="serviceKey">serviceKey，服务的唯一标识</param>
        object GetService(string serviceKey);

    }
}