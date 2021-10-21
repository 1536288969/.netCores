using Common.AutofacManager;
using Common.OrderByExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public  interface IRepository<TEntity> where TEntity :class
    {
        /// <summary>
        /// 事务
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();
        /// <summary>
        /// 添加到数据库，普通的EF操作，需要自行调用Save用来持久化到数据库
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 根据Entity删除，且需要调用Save持久化到数据库
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 根据表达式树删除，需要调用Save持久化到数据库
        /// </summary>
        /// <param name="exp"></param>
        int Delete(Expression<Func<TEntity, bool>> exp);

        /// <summary>
        /// 修改数据库数据，普通EF操作，需要自行调用Save方法
        /// </summary>
        /// <param name="entity"></param>
        void Modify(TEntity entity);

        /// <summary>
        /// 查询，返回Entity对象
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> exp);

        /// <summary>
        /// 查询，返回Entity对象
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> exp);

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> exp,
                              IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false);

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        IQueryable<TEntity> Query(IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false);

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> exp,
                                         IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false);

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false);

        /// <summary>执行SQL
        /// 
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
       // List<T> SqlQuery<T>(string sql) where T : class;

        /// <summary>执行SQL
        /// 
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
      //  List<T> SqlQuery<T>(string sql, params object[] parameters) where T : class;

        /// <summary>根据条件分页
        /// 
        /// </summary>
        /// <param name="funcWhere">查询条件</param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="totalPage">总页数</param>
        /// <param name="totalRecord">总记录</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        IQueryable<TEntity> PageQueryable(Expression<Func<TEntity, bool>> funcWhere,
                                          IOrderByExpression<TEntity>[] orderByExpressions, int pageSize, int pageIndex,
                                          out int totalPage, out int totalRecord, bool isProxyCreationEnabled = false,
                                          bool asNoTracking = false);

        /// <summary>根据条件分页
        /// 
        /// </summary>
        /// <param name="funcWhere">查询条件</param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        IQueryable<TEntity> PageQueryable(Expression<Func<TEntity, bool>> funcWhere,
                                          IOrderByExpression<TEntity>[] orderByExpressions, bool isProxyCreationEnabled = false,
                                          bool asNoTracking = false);

        /// <summary>
        /// 保存,带泛型的快速操作方法以及查询操作不需要调用
        /// </summary>
        /// <returns></returns>
        int Save();

        /// <summary>
        /// 保存,带泛型的快速操作方法以及查询操作不需要调用
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();
    }
}
