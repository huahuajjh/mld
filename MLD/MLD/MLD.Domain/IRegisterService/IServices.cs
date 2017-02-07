namespace MLD.Domain.IRegisterService
{
    /// <summary>
    /// 定义获取工厂的接口
    /// </summary>
    public interface IServices
    {
        /// <summary>
        /// 获取一个服务工厂
        /// </summary>
        /// <typeparam name="T">工厂生产的服务实例类型</typeparam>
        /// <returns>服务工厂</returns>
        IServicesFactory<T> GetServicesFactory<T>() where T : class;
    }
}
