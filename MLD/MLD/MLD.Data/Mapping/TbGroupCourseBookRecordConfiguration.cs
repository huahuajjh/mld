using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MLD.Entity;


namespace MLD.Data.Mapping
{
    internal partial class TbGroupCourseBookRecordConfiguration : EntityTypeConfiguration<TbGroupCourseBookRecord>
    {
        public TbGroupCourseBookRecordConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tbGroupCourseBookRecord");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("userId").IsRequired();
            Property(x => x.GrpCrsId).HasColumnName("grpCrsId").IsRequired();
            Property(x => x.Remarks).HasColumnName("remarks").IsOptional().HasMaxLength(50);
            Property(x => x.Del).HasColumnName("del").IsRequired();
            Property(x => x.BookState).HasColumnName("bookState").IsOptional();
            Property(x => x.BookPersonNum).HasColumnName("bookPersonNum").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}