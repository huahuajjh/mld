using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MLD.IRepository;

namespace MLD.Repository
{
    /// <summary>
    /// 仓储实现类，提供数据持久化操作
    /// </summary>
    /// <typeparam name="T">实体类型参数</typeparam>
    public class BaseRepository<T> : Base, IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 新增实体方法，将实体持久化到DB
        /// </summary>
        /// <param name="model">被持久化的model</param>
        public void Add(T model)
        {
            DbContext.Set<T>().Add(model);
        }

        /// <summary>
        /// 批量新增实体到DB
        /// </summary>
        /// <param name="list">待新增的实体集合</param>
        public void Add(IEnumerable<T> list)
        {
            //DbContext.Set<T>().AddRange(list);
            foreach (var model in list)
            {
                this.Add(model);
            }
        }

        /// <summary>
        /// 从DB中删除对象
        /// </summary>
        /// <param name="model"> 待删除的model</param>
        public void Delete(T model)
        {
            //DbContext.Set<T>().Attach(model);
            DbContext.Set<T>().Remove(model);
        }

        public void Delete(object id)
        {
            var entity = DbContext.Set<T>().Find(id);
            Delete(entity);
        }

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        public void Delete(Expression<Func<T, bool>> whereLambda)
        {
            IEnumerable<T> list = DbContext.Set<T>().Where(whereLambda);
            foreach (var model in list)
            {
                this.Delete(model);
            }
            //DbContext.Set<T>().Delete(whereLambda);
        }

        /// <summary>
        /// 批量删除操作
        /// </summary>
        /// <param name="list">待删除的集合</param>
        public void Delete(IEnumerable<T> list)
        {
            foreach (var model in list)
            {
                this.Delete(model);
            }
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model">待修改的实体</param>
        public void Modify(T model)
        {
            throw new NotImplementedException("未实现的方法,请使用SaveChanges()方法修改数据");
        }

        /// <summary>
        /// 根据条件更新数据
        /// </summary>
        /// <param name="whereLambda">条件</param>
        public void Modify(Expression<Func<T, bool>> whereLambda)
        {
            throw new NotImplementedException("未实现的方法,请使用SaveChanges()方法修改数据");
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">待修改的实体集合</param>
        public void Modify(IEnumerable<T> list,Expression<Func<T,bool>> whereLambda)
        {
            //DbContext.Set<T>().Update<T>((IQueryable<T>) list,whereLambda);
            foreach (var model in list)
            {
                this.Modify(model);
            }
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns>查询到的实体集合</returns>
        public IQueryable<T> Query(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().Where(whereLambda);
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>实体对象</returns>
        public T Query(object id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IQueryable<T> ExecuteStoredProcedure(string query, params object[] parameters)
        {
            return DbContext.ExecuteStoredProcedure<T>(query,parameters);
        }

        public IQueryable<T> SqlQuery(string query, params object[] parameters)
        {
            return DbContext.Set<T>().SqlQuery(query,parameters).AsQueryable();
        }

        public IRepositoryQuery<T> Query()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> QueryByPage<TKey>(Expression<Func<T, T>> select, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderCondition, int pageSize, int pageIndex, out int pageCount)
        {
            pageCount = DbContext.Set<T>().Where(where).Count();
            var list =
                DbContext.Set<T>()
                    .Where(where)
                    .OrderBy(orderCondition)
                    //.Select(select)
                    .Skip(pageIndex)
                    .Take(pageSize).Cast<T>();
            return list;
        }
    }
}
