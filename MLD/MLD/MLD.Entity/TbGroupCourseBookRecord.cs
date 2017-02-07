namespace MLD.Entity
{
    /// <summary>
    /// description:团课预约记录表 | record group course subsribe
    /// author:jjh
    /// date:2015-07-25 12:57
    /// last modify date:2015-07-25 12:57
    /// </summary>
    public partial class TbGroupCourseBookRecord
    {
        public int Id { get; set; } // id (Primary key)
        public int UserId { get; set; } // userId
        public int GrpCrsId { get; set; } // grpCrsId
        public string Remarks { get; set; } // remarks
        public bool Del { get; set; } // del
        public int? BookState { get; set; } // bookState
        public int BookPersonNum { get; set; }  //bookPersonNum
        
    }
}