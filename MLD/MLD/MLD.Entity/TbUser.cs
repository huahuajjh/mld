using System;
using MLD.ViewModel.Back;
using MLD.ViewModel.State;

namespace MLD.Entity
{
    /// <summary>
    /// description:用户信息 | user information
    /// author:jjh
    /// date:2015-07-25 12:57
    /// last modify date:2015-07-25 12:57
    /// </summary>
    public partial class TbUser
    {
        public int Id { get; set; } // id (Primary key)
        public string UserTel { get; set; } // userTel
        public string Pwd { get; set; } // pwd
        public string Name { get; set; } // name
        public bool Del { get; set; }   // del
        public DateTime? Birthday { get; set; }
        public int? BuyClassNum { get; set; }
        public int? CostClassNum { get; set; }
        public string Remarks { get; set; }
        public int? Validity { get; set; }
        public bool? Gender { get; set; }

        public TbUser()
        {
            Pwd = "";
        }

        public User ToBackUser()
        {
            return new User()
            {
                Name = this.Name,
                Tel = this.UserTel
            };
        }

        /// <summary>
        /// 消费一节课程
        /// </summary>
        public void Cost1Course()
        {
            if (BuyClassNum == 0)
            {
                return;
            }

            if (CostClassNum == BuyClassNum)
            {
                return;
            }
            CostClassNum += 1;
        }

        /// <summary>
        /// 检测用户是否可以预约,已经消耗完毕课时不能预约，没有购买课时不能预约等
        /// </summary>
        /// <returns></returns>
        public ReservationCourseState CanAppointment()
        {
            if (BuyClassNum <= 0)
            {
                return ReservationCourseState.NoCourseNum;
            }
            if (BuyClassNum == CostClassNum)
            {
                return ReservationCourseState.CourseCostedAll;
            }
            //是否在可预约范围内
            
            return ReservationCourseState.Success;
        }

    }
}