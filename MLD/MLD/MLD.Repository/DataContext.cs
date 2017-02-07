using System;
using System.Data.Entity;
using System.Linq;
using MLD.IRepository;

namespace MLD.Repository
{
    /// <summary>
    /// description:数据库上下文接口实现类 | repository interface
    /// author:jjh
    /// date:2015-07-25 15:23
    /// last modify date:2015-07-25 15:23
    /// </summary>
    public class DataContext : DbContext, IDataContext
    {
        private readonly Guid _instanceId;

        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            _instanceId = Guid.NewGuid();
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
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
            return base.Database.SqlQuery<T>(query,parameters).AsQueryable();
        }

        public new void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
