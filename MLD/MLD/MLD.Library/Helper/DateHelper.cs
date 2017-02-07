using System;

namespace MLD.Library.Helper
{
    /// <summary>
    /// 时间处理帮助类
    /// </summary>
    public static class DateHelper
    {
        /// <summary>
        /// 计算两个时间的间隔,返回小时数
        /// </summary>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public static int DiffTime(DateTime startTime,DateTime endTime)
        {
            var startTimeSpan = new TimeSpan(startTime.Ticks);
            var endTimeSpan = new TimeSpan(endTime.Ticks);
            var rs = endTimeSpan.Subtract(startTimeSpan);
            return rs.Days*24+rs.Hours;
        }
    }
}
