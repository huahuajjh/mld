namespace MLD.Library.Constant
{
    /// <summary>
    /// description:需求服务类的类名，该名称作为寻找该服务的唯一编号 | service name, which is used to find itself
    /// author:jjh
    /// date:2015-07-26 09:55
    /// last modify date:2015-07-26 09:55
    /// </summary>
    public sealed class ServiceName
    {
        /// <summary>
        /// 登陆需求实现类key
        /// </summary>
        public const string LOGINKEY = "MLD.Domain.Login.LoginImpl";

        /// <summary>
        /// 客户端团课查询等key
        /// </summary>
        public const string GROUPCOURSE = "MLD.Domain.Course.GroupCourseImpl";

        /// <summary>
        /// 后台团课管理key
        /// </summary>
        public const string GRPCOURSEMANAGEMEMT = "MLD.Domain.BackGrpCourseManagement.BackGrpCursManageImpl";

        /// <summary>
        /// 用户管理key
        /// </summary>
        public const string USERMANAGEMENT = "MLD.Domain.Usermanagement.UserManagementImpl";

    }
}
