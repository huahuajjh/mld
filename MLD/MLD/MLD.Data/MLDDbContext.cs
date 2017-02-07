using System;
using System.Data.Entity;
using System.Linq;
using MLD.Data.Mapping;
using MLD.IRepository;

namespace MLD.Data
{
    public class MLDDbContext : DbContext,IDataContext//, IMLDContext
    {
        private readonly Guid _instanceId;

        static MLDDbContext()
        {
            Database.SetInitializer<MLDDbContext>(null);

        }

        public MLDDbContext() : base("Name=MLD_DB_ConnStr")
        {
            _instanceId = Guid.NewGuid();
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new TbGroupCourseConfiguration());
            modelBuilder.Configurations.Add(new TbGroupCourseBookRecordConfiguration());
            modelBuilder.Configurations.Add(new TbUserConfiguration());
        }

        public Guid InstanceId
        {
            get { return _instanceId; }
        }

        public new Database Database
        {
            get { return base.Database; }
        }

        public new DbSet<T> Set<T>() where T : class { return base.Set<T>(); }

        public override int SaveChanges()
        {
            int changes = base.SaveChanges();
            return changes;
        }

        public IQueryable<T> ExecuteStoredProcedure<T>(string query, params object[] parameters)
        {
            return base.Database.SqlQuery<T>(query, parameters).AsQueryable();
        }

    }
}
