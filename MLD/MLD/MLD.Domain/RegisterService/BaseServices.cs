using MLD.Domain.IRegisterService;

namespace MLD.Domain.RegisterService
{
    /// <summary>
    /// 服务基类，公共服务
    /// </summary>
    /// <typeparam name="T">具体需求的服务类型</typeparam>
    public class BaseServices<T>:IBaseServices<T> where T : class
    {
    }

}
