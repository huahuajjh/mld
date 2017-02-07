namespace MLD.IPresentation
{
    /// <summary>
    /// 需求接口，表示所有登陆领域的需求
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// 登陆需求api | sign in demand api
        /// </summary>
        /// <param name="username">用户名 | username</param>
        /// <param name="pwd">密码 | pwd</param>
        /// <param name="remember">是否记住密码 | if remember password</param>
        /// <returns>反馈给客户端消息 | message which is feedback to client</returns>
        string Login(string username,string pwd,bool remember = false);

        /// <summary>
        /// 设置用户session
        /// </summary>
        /// <param name="key">session key</param>
        /// <param name="value">sessoin value</param>
        void SetSession(string key, object value);

        /// <summary>
        /// 设置客户端cookie
        /// </summary>
        /// <param name="key">cookie key</param>
        /// <param name="value">cookie value</param>
        void SetCookie(string key, string value);
        
    }
}
