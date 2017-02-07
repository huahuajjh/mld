using System;

namespace MLD.Library.Helper
{
    /// <summary>
    /// 判断数据类型
    /// </summary>
    public static class Vilidate
    {
        /// <summary>
        /// 判断数据是否是日期类型
        /// </summary>
        /// <param name="date">待判断的数据</param>
        /// <returns>判断后的bool值</returns>
        public static bool IsDate(string date)
        {
            var dt = new DateTime();
            bool flag = DateTime.TryParse(date, out dt);
            return flag;
        }

        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="target">待检查的字符串</param>
        /// <returns>如果为null返回false，反之tr返回ue</returns>
        public static bool IsNull(this string target)
        {
            if (string.IsNullOrWhiteSpace(target))
                return true;
            return false;
        }
    }
}
