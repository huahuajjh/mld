using System.Collections.Generic;
using MLD.Domain.IRegisterService;

namespace MLD.Domain.RegisterService
{
    /// <summary>
    /// 服务注册器，该类无法被继承，提供用户需求服务注册机制，当用户需求服务时，注册服务实现类
    /// </summary>
    public sealed class ServicesRegister:IServicesRegister
    {
        private static ServicesRegister _instance;

        //fields
        /// <summary>
        /// 服务列表，列表维护所有注册到到字典的服务
        /// </summary>
        private static Dictionary<string, object> _servicesDic;

        public ServicesRegister()
        {
            _servicesDic = new Dictionary<string, object>();
        }

        /// <summary>
        /// 获取注册器实例
        /// </summary>
        /// <returns>注册器实例</returns>
        public static ServicesRegister GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ServicesRegister();
                if (null == _servicesDic) { _servicesDic = new Dictionary<string, object>(); }
                return _instance;
            }
            if (null == _servicesDic) { _servicesDic = new Dictionary<string, object>(); }
            return _instance;
        }

        /// <summary>
        /// 服务注册方法，注册服务进去
        /// </summary>
        /// <param name="serviceKey">服务key，唯一标识服务，便于标识，建议使用服务类的全限定名称</param>
        /// <param name="service">被注册的服务对象</param>
        public void RegisteService(string serviceKey,object service)
        {
            if (string.IsNullOrEmpty(serviceKey) || null == service)
                return;

            //注册服务
            _servicesDic.Add(serviceKey,service); 
        }

        /// <summary>
        /// 根据serviceKey获取服务
        /// </summary>
        /// <param name="serviceKey">serviceKey，服务的唯一标识</param>
        public object GetService(string serviceKey)
        {
            if (string.IsNullOrWhiteSpace(serviceKey))
            {
                return null;
            }

            return _servicesDic[serviceKey];
        }
        
    }
}
