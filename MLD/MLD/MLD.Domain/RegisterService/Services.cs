using MLD.Domain.IRegisterService;

namespace MLD.Domain.RegisterService
{
    /// <summary>
    /// 该类提供服务工厂接口
    /// </summary>
    public class Services:IServices
    {
        /// <summary>
        /// 返回一个生产服务的接口工厂，工厂生产的服务继承表现层的需求接口
        /// </summary>
        /// <typeparam name="T">类型参数，该参数类型是表现层接口的需求实现类</typeparam>
        /// <returns>服务工厂接口</returns>
        public IServicesFactory<T> GetServicesFactory<T>() where T : class
        {
            return ServicesFactory<T>.GetInstance();
        }
    }
}
