using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLD.ViewModel.State
{
    /// <summary>
    /// 预约课程状态
    /// </summary>
    public enum ReservationCourseState
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("预约成功")]
        Success = 0,

        /// <summary>
        /// 人数已满
        /// </summary>
        [Description("预约已满")]
        Failure = 1,

        /// <summary>
        /// 重复预约
        /// </summary>
        [Description("号码已预约")]
        Repeat = 2,

        /// <summary>
        /// 课程不存在
        /// </summary>
        [Description("课程不存在")]
        NotExist = 3,

        /// <summary>
        /// 该电话对应的用户不存在
        /// </summary>
        [Description("用户不存在")]
        UserNotExist = 4,

        /// <summary>
        /// 预约过期
        /// </summary>
        [Description("预约过期")]
        Expire = 5,

        /// <summary>
        /// 没有购买课时
        /// </summary>
        [Description("购买课时不够或者课时消耗完毕")]
        NoCourseNum = 6,

        /// <summary>
        /// 课时消耗完毕
        /// </summary>
        [Description("课时消耗完毕")]
        CourseCostedAll = 7,

        /// <summary>
        /// 不能提前超过1天预约
        /// </summary>
        [Description("您太提前了,请提前1天之内预约")]
        TooEarly = 8

    }
}
