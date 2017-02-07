using System.Collections.Generic;

namespace MLD.IPresentation
{
    public interface IUser
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="count">用户总数</param>
        /// <param name="index">开始下标</param>
        /// <param name="lenght">显示数量</param>
        /// <param name="telNum">查找的联系号码（null或者空 表示查询全部）</param>
        /// <returns>用户列表</returns>
        IList<MLD.Entity.TbUser> Get(out int count,int index,int lenght,string telNum);

        /// <summary>
        /// 根据编号获取详细信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>用户的详细信息</returns>
        MLD.Entity.TbUser Get(int id);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>新增状态</returns>
        bool Add(IList<MLD.Entity.TbUser> user);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">用户修改数据</param>
        /// <returns>修改状态</returns>
        bool Edit(MLD.Entity.TbUser user);

        /// <summary>
        /// 根据指定的ID删除用户
        /// </summary>
        /// <param name="id">用户编号</param>
        void Delete(int id);
    }
}
