using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MLD.Entity;

namespace MLD.Data.Mapping
{
    internal partial class TbGroupCourseConfiguration : EntityTypeConfiguration<TbGroupCourse>
    {
        public TbGroupCourseConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tbGroupCourse");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            Property(x => x.CourseDate).HasColumnName("courseDate").IsRequired();
            Property(x => x.StartTime).HasColumnName("startTime").IsRequired();
            Property(x => x.EndTime).HasColumnName("endTime").IsRequired();
            Property(x => x.MaxPersons).HasColumnName("maxPersons").IsRequired();
            Property(x => x.Img).HasColumnName("img").IsOptional().HasMaxLength(150);
            Property(x => x.Addr).HasColumnName("addr").IsRequired().HasMaxLength(50);
            Property(x => x.Del).HasColumnName("del").IsRequired();
            Property(x => x.Descrp).HasColumnName("descrp").IsOptional().HasMaxLength(1000);
            Property(x => x.MaxPersonsOnce).HasColumnName("maxPersonOnce").IsRequired();
            Property(x => x.BookHowManyPerosonNum).HasColumnName("bookHowManyPerosonNum").IsRequired();
            Property(x => x.CourseState).HasColumnName("courseState").IsRequired();
            Property(x => x.AppointmentPersonNum).HasColumnName("appointmentPersonNum").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}