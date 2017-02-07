using System;
using MLD.Library.Constant;
using MLD.Library.Helper;
using MLD.Library.SerializeHelper;
using MLD.ViewModel;
using MLD.ViewModel.State;

namespace MLD.Entity
{
    /// <summary>
    /// description:团课课程表 | group course
    /// author:jjh
    /// date:2015-07-25 12:55
    /// last modify date:2015-07-25 12:55  
    /// </summary>
    public partial class TbGroupCourse
    {
        public int Id { get; set; } // id (Primary key)
        public string Name { get; set; } // name
        public DateTime CourseDate { get; set; } // courseDate
        public DateTime StartTime { get; set; } // startTime
        public DateTime EndTime { get; set; } // endTime
        public int MaxPersons { get; set; } // maxPersons
        public string Img { get; set; } // img
        public string Addr { get; set; } // addr
        public bool Del { get; set; } // del
        public string Descrp { get; set; } // descrp
        public int MaxPersonsOnce { get; set; } //maxPersonsOnce
        public int BookHowManyPerosonNum { get; set; }  //bookHowManyPerosonNum
        public int CourseState { get; set; }    //courseState
        public int AppointmentPersonNum { get; set; } //appointmentPersonNum

        public CourseList ToCourseList()
        {
            return new CourseList()
            {
                CourseId = this.Id,
                Name = this.Name,
                StartTime = TimeSpan.Parse(this.StartTime.Hour.ToString() + ":" + this.StartTime.Minute.ToString()),
                EndTime = TimeSpan.Parse(this.EndTime.Hour.ToString() + ":" + this.EndTime.Minute.ToString()),
                Addr = this.Addr,
                Img = ConfigFileHelper.GetAppSettingValue(DiKey.IMGDIR) + this.Img,
                PersonNum = this.MaxPersons - this.AppointmentPersonNum
            };
        }

        public Course ToCourse()
        {
            return new Course()
            {
                CourseAddr = this.Addr,
                CourseId = this.Id,
                CourseName = this.Name,
                StartTime = TimeSpan.Parse(this.StartTime.Hour.ToString() + ":" + this.StartTime.Minute.ToString()),
                EndTime = TimeSpan.Parse(this.EndTime.Hour.ToString() + ":" + this.EndTime.Minute.ToString()),
                CourseDate = this.CourseDate,
                Img = ConfigFileHelper.GetAppSettingValue(DiKey.IMGDIR) + this.Img
            };
        }

        public CourseInfo ToCourseInfo()
        {
            return new CourseInfo()
            {
                Addr = this.Addr,
                CourseDate = this.CourseDate,
                CourseState = this.GetCourseState(),
                StartTime = TimeSpan.Parse(this.StartTime.Hour.ToString() + ":" + this.StartTime.Minute.ToString()),
                EndTime = TimeSpan.Parse(this.EndTime.Hour.ToString() + ":" + this.EndTime.Minute.ToString()),
                Id = this.Id,
                Img = ConfigFileHelper.GetAppSettingValue(DiKey.IMGDIR) + this.Img,
                Introduce = this.Descrp,
                Name = this.Name,
                PersonNum = this.BookHowManyPerosonNum
            };
        }

        private ViewModel.State.CourseState GetCourseState()
        {
            switch (this.CourseState)
            {
                case 0:
                    return ViewModel.State.CourseState.ReservationNotFull;

                case 1:
                    return ViewModel.State.CourseState.ReservationFull;

                default:
                    return ViewModel.State.CourseState.ReservationNotFull;

            }
        }

        public ReservationCourseState CanBook()
        {
            if (MaxPersons == AppointmentPersonNum)
            {
                //预约满
                return ReservationCourseState.Failure;
            }

            DateTime now = DateTime.Now;

            var time = this.StartTime - now;

            //get time span
            var rs = DateHelper.DiffTime(now , StartTime);

            if (rs > 24)
            {
                return ReservationCourseState.TooEarly;
            }

            if (time.Hours < 0)
            {
                return ReservationCourseState.Expire;
            }

            return ReservationCourseState.Success;
        }

        public CancelCourseState CanCancelBook()
        {
            //取消时间
            var now = DateTime.Now;//this.StartTime - now
            var rs = DateHelper.DiffTime(now, StartTime);
            if (rs <= 4)
            {
                return CancelCourseState.NotTimeRange;
            }
            return CancelCourseState.CancelSuccess;
        }

        public ViewModel.Back.Course ToBackCourse()
        {
            return new ViewModel.Back.Course()
            {
                CourseDate = this.CourseDate.ToString("d"),
                Id = this.Id,
                Name = this.Name,
                PersonNum = this.AppointmentPersonNum,
                Time = this.StartTime.Hour + ":" + StartTime.Minute + " - " + this.EndTime.Hour + ":" + this.EndTime.Minute
            };
        }
    }

}