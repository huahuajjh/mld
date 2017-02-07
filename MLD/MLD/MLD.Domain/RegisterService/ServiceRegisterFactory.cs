using MLD.Domain.IRegisterService;

namespace MLD.Domain.RegisterService
{
    /// <summary>
    /// 服务注册器工厂，用于返回服务注册器,此类不能被继承
    /// </summary>
    public sealed class ServiceRegisterFactory
    {
        /// <summary>
        /// 创建返回初始化注册器
        /// </summary>
        /// <returns>服务注册器</returns>
        public static IServicesRegister CreateServiceRegister()
        {
            return new ServicesRegister();
        }
    }
}
