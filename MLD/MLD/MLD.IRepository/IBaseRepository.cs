using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MLD.IRepository
{
    /// <summary>
    /// 仓储父接口，提供公共的增删查改操作规范
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 新增实体方法，将实体持久化到DB
        /// </summary>
        /// <param name="model">被持久化的model</param>
        void Add(T model);

        /// <summary>
        /// 批量新增实体到DB
        /// </summary>
        /// <param name="list">待新增的实体集合</param>
        void Add(IEnumerable<T> list);

        /// <summary>
        /// 从DB中删除对象
        /// </summary>
        /// <param name="model"> 待删除的model</param>
        void Delete(T model);

        /// <summary>
        /// 根据id删除对象 | delete object by id
        /// </summary>
        /// <param name="id">id</param>
        void Delete(object id);

        /// <summary>
        /// 根据条件删除数据
        /// </summary>
        /// <param name="whereLambda">条件表达式</param>
        void Delete(Expression<Func<T,bool>> whereLambda);

        /// <summary>
        /// 批量删除操作
        /// </summary>
        /// <param name="list">待删除的集合</param>
        void Delete(IEnumerable<T> list);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model">待修改的实体</param>
        void Modify(T model);

        /// <summary>
        /// 根据条件修改数据
        /// </summary>
        /// <param name="whereLambda">修改条件</param>
        void Modify(Expression<Func<T,bool>> whereLambda);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">待修改的实体集合</param>
        /// <param name="whereLambda">条件</param>
        void Modify(IEnumerable<T> list, Expression<Func<T, bool>> whereLambda);
        
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <returns>查询到的实体集合</returns>
        IQueryable<T> Query(Expression<Func<T,bool>> whereLambda);

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>实体对象</returns>
        T Query(object id);

        /// <summary>
        /// 获取存储过程的结果集 | get result set from StoredProcedure
        /// </summary>
        /// <param name="query">执行存储过程语句 | execute StoredProcedure statement</param>
        /// <param name="parameters">存储过程参数 | StoredProcedure parameters</param>
        /// <returns>结果集 | result set</returns>
        IQueryable<T> ExecuteStoredProcedure(string query,params object[] parameters);

        /// <summary>
        /// 根据sql查询语句查询结果 | get query result set according to query statement
        /// </summary>
        /// <param name="query">sql语句 | sql statement</param>
        /// <param name="parameters">查询参数 | query parameters</param>
        /// <returns>结果集 | result set</returns>
        IQueryable<T> SqlQuery(string query,params object[] parameters);

        /// <summary>
        /// 查询接口，独立的查询对象，该接口返回一个查询对象，通过查询对象可以实现更丰富的查询结果和查询条件
        /// </summary>
        /// <returns>查询结果对象 | query result object</returns>
        IRepositoryQuery<T> Query();

        /// <summary>
        /// 分页查询 | query by pagenation
        /// </summary>
        /// <param name="select"></param>
        /// <param name="where">查询条件 | query condition</param>
        /// <param name="orderCondition">筛选条件 | order condition</param>
        /// <param name="pageSize">页大小 | page size</param>
        /// <param name="pageIndex">起始页 | page index</param>
        /// <param name="pageCount">总记录数 | page count</param>
        /// <returns>对象集合</returns>
        IQueryable<T> QueryByPage<TKey>(Expression<Func<T, T>> select, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> orderCondition, int pageSize, int pageIndex, out int pageCount);

    }
}
