using System;
using MLD.Domain.BackGrpCourseManagement;
using MLD.Domain.Course;
using MLD.Domain.IRegisterService;
using MLD.Domain.Login;
using MLD.Domain.Usermanagement;
using MLD.Library.Constant;

namespace MLD.Domain.RegisterService
{
    /// <summary>
    /// 服务工厂，该工厂产生服务
    /// </summary>
    /// <typeparam name="T">服务具体类型参数</typeparam>
    public class ServicesFactory<T> : IServicesFactory<T> where T : class
    {
        private static ServicesFactory<T> _instance;

        //ctors
        /// <summary>
        /// 初始化服务工厂
        /// </summary>
        private ServicesFactory()
        {
            //通过工厂获取服务注册器
            this._register = ServiceRegisterFactory.CreateServiceRegister();

            //注册服务
            _register.RegisteService(ServiceName.LOGINKEY,new LoginImpl());
            _register.RegisteService(ServiceName.GROUPCOURSE,new GroupCourseImpl());
            _register.RegisteService(ServiceName.GRPCOURSEMANAGEMEMT,new BackGrpCursManageImpl());
            _register.RegisteService(ServiceName.USERMANAGEMENT, new UserManagementImpl());

        }

        /// <summary>
        /// 获取对象实例
        /// </summary>
        /// <returns>该对象实例</returns>
        public static ServicesFactory<T> GetInstance()
        {
            if (null == _instance)
            {
                _instance = new ServicesFactory<T>();
                return _instance;
            }
            return _instance;
        }


        //methods
        /// <summary>
        /// 返回公共服务，或者其泛型服务
        /// </summary>
        public IBaseServices<T> Service
        {
            get
            {
                return new BaseServices<T>();
            }
        }

        /// <summary>
        /// 根据服务key获取服务
        /// </summary>
        /// <param name="serviceKey">服务key</param>
        /// <returns>服务对象接口</returns>
        public T GetService(string serviceKey)
        {
            if (string.IsNullOrWhiteSpace(serviceKey))
            {
                throw new Exception("Exception:禁止传入空值");
            }
            return this._register.GetService(serviceKey) as T;
        }

        //fields
        private readonly IServicesRegister _register;
    }
}
