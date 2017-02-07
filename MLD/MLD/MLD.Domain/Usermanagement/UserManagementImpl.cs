using System;
using System.Collections.Generic;
using System.Linq;
using MLD.Entity;
using MLD.IPresentation;

namespace MLD.Domain.Usermanagement
{
    public class UserManagementImpl : Base, IUser
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="count">用户总数</param>
        /// <param name="index">开始下标</param>
        /// <param name="lenght">显示数量</param>
        /// <param name="telNum">查找的联系号码（null或者空 表示查询全部）</param>
        /// <returns>用户列表</returns>
        public IList<TbUser> Get(out int count, int index, int lenght, string telNum)
        {
            if (String.IsNullOrWhiteSpace(telNum))
            {
                return GetRepository<TbUser>().QueryByPage(null, u => u.Del == false, a => a.Id, lenght, index, out count).ToList();
            }
            return GetRepository<TbUser>().QueryByPage(null, u => u.Del == false && u.UserTel == telNum, a => a.Id, lenght, index, out count).ToList();
        }

        /// <summary>
        /// 根据编号获取详细信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns>用户的详细信息</returns>
        public TbUser Get(int id)
        {
            return GetRepository<TbUser>().Query(id);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>新增状态</returns>
        public bool Add(IList<TbUser> user)
        {
            if (null == user) { return false; }
            try
            {
                GetRepository<TbUser>().Add(user);
                Repository.SaveChange();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user">用户修改数据</param>
        /// <returns>修改状态</returns>
        public bool Edit(TbUser tbUser)
        {
            if (null == tbUser) { return false; }
            try
            {
                var user = GetRepository<TbUser>().Query(u => u.Id == tbUser.Id && u.Del == false).FirstOrDefault();
                if (null == tbUser){return false;}

                user.UserTel = tbUser.UserTel;
                user.Pwd = "";
                user.Name = tbUser.Name;
                user.Del = tbUser.Del;
                user.Birthday = tbUser.Birthday;
                user.BuyClassNum = tbUser.BuyClassNum;
                user.CostClassNum = tbUser.CostClassNum;
                user.Remarks = tbUser.Remarks;
                user.Validity = tbUser.Validity;
                user.Gender = tbUser.Gender;

                Repository.SaveChange();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 根据指定的ID删除用户
        /// </summary>
        /// <param name="id">用户编号</param>
        public void Delete(int id)
        {
            var user = GetRepository<TbUser>().Query(u=>u.Del == false && u.Id == id).FirstOrDefault();
            if (null == user){return;}

            user.Del = true;
            Repository.SaveChange();
        }
    }
}
