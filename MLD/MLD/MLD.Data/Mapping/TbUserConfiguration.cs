using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MLD.Entity;

namespace MLD.Data.Mapping
{
    internal partial class TbUserConfiguration : EntityTypeConfiguration<TbUser>
    {
        public TbUserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tbUser");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserTel).HasColumnName("userTel").IsRequired().HasMaxLength(11);
            Property(x => x.Pwd).HasColumnName("pwd").IsRequired().HasMaxLength(50);
            Property(x => x.Name).HasColumnName("name").IsOptional().HasMaxLength(50);
            Property(x => x.Del).HasColumnName("del").IsRequired();
            Property(x => x.Birthday).HasColumnName("birthday").IsOptional();
            Property(x => x.BuyClassNum).HasColumnName("buyClassNum").IsRequired();
            Property(x => x.CostClassNum).HasColumnName("costClassNum").IsRequired();
            Property(x => x.Remarks).HasColumnName("remarks").IsOptional();
            Property(x => x.Validity).HasColumnName("validity").IsRequired();
            Property(x => x.Gender).HasColumnName("gender").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}