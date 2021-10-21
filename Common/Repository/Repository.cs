
using Common.AutofacManager;
using Common.OrderByExpressions;
using Common.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Utility;
using Z.EntityFramework.Plus;

namespace Common.Repository
{
    public class Repository<TEntity>:  IRepository<TEntity> where TEntity : class
    {
        protected  DataDBContext Context { get; }

        protected DbSet<TEntity> Set;
        public Repository(DataDBContext dataDBContext)
        {
            //Context = dataDBContext ??
            //    throw new Exception("dbContext未实例化。");
            Context = dataDBContext;
        }

        
     
        protected DbSet<TEntity> DbSet => Set ?? (Set = Context.Set<TEntity>());

        #region 事务
        public IDbContextTransaction BeginTransaction()
        {
             return Context.Database.BeginTransaction();         
        }

         #endregion

        #region 添加

    /// <summary>
    /// 添加到数据库，普通的EF操作，需要自行调用Save用来持久化到数据库
    /// </summary>
    /// <param name="entity"></param>
    public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        #endregion

        #region 删除
        /// <inheritdoc />
        /// <summary>
        /// 根据Entity删除，且需要调用Save持久化到数据库
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        /// <inheritdoc />
        /// <summary>
        /// 根据表达式树删除
        /// </summary>
        /// <param name="exp"></param>
        public int Delete(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.Where(exp).Delete();
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改数据库数据，普通EF操作，需要自行调用Save方法
        /// </summary>
        /// <param name="entity"></param>
        public void Modify(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// 根据表达式树修改
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        public int Modify(Expression<Func<TEntity, bool>> exp, Expression<Func<TEntity, TEntity>> tEntity)
        {
            return DbSet.Where(exp).Update(tEntity);
        }

        #endregion

        #region 单记录查看
        /// <summary>
        /// 查询，返回Entity对象
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual TEntity Find(Expression<Func<TEntity, bool>> exp)
        {
            return DbSet.FirstOrDefault(exp);
        }
        /// <summary>
        /// 查询，返回Entity对象
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> exp)
        {
            return await DbSet.FirstOrDefaultAsync(exp);
        }

        #endregion

        #region 多条记录查看
        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> exp, IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false)
        {

            if (orderByExpressions == null)
            {
                if (exp == null)
                {
                    return !asNoTracking ? DbSet.AsNoTracking() : DbSet;
                }
                return !asNoTracking ? DbSet.AsNoTracking().Where(exp) : DbSet.Where(exp);
            }
            if (exp == null)
            {
                return !asNoTracking
                           ? ExpressionPager.ApplyOrder(DbSet, orderByExpressions).AsNoTracking()
                           : ExpressionPager.ApplyOrder(DbSet, orderByExpressions);
            }
            return !asNoTracking ? ExpressionPager.ApplyOrder(DbSet, orderByExpressions).AsNoTracking().Where(exp) : ExpressionPager.ApplyOrder(DbSet, orderByExpressions).Where(exp);
        }

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Query(IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false)
        {

            if (orderByExpressions == null)
            {
                return !asNoTracking ? DbSet.AsNoTracking() : DbSet;
            }
            return !asNoTracking ? ExpressionPager.ApplyOrder(DbSet, orderByExpressions).AsNoTracking() : ExpressionPager.ApplyOrder(DbSet, orderByExpressions);
        }

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> exp, IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false)
        {

            if (orderByExpressions == null)
            {
                return await (!asNoTracking ? DbSet.AsNoTracking().Where(exp).ToListAsync() : DbSet.Where(exp).ToListAsync());
            }
            return await (!asNoTracking ? ExpressionPager.ApplyOrder(DbSet, orderByExpressions).AsNoTracking().Where(exp).ToListAsync() : ExpressionPager.ApplyOrder(DbSet, orderByExpressions).Where(exp).ToListAsync());
        }

        /// <summary>
        /// 查询，返回Entity列表
        /// </summary>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> QueryAsync(IOrderByExpression<TEntity>[] orderByExpressions = null, bool isProxyCreationEnabled = false, bool asNoTracking = false)
        {

            if (orderByExpressions == null)
            {
                return await (!asNoTracking ? DbSet.AsNoTracking().ToListAsync() : DbSet.ToListAsync());
            }
            return await (!asNoTracking ? ExpressionPager.ApplyOrder(DbSet, orderByExpressions).AsNoTracking().ToListAsync() : ExpressionPager.ApplyOrder(DbSet, orderByExpressions).ToListAsync());
        }

        #endregion

        #region SQL查询

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
    
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parm">参数</param>
        public bool ExecuteSqlCommand(string sql, SqlParameter[] parm)
        {
            try
            {
                if (parm == null)
                {
                    return Context.Database.ExecuteSqlRaw(sql) > 0;
                }
                return Context.Database.ExecuteSqlRaw(sql, parm) > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region 分页

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
        public virtual IQueryable<TEntity> PageQueryable(Expression<Func<TEntity, bool>> funcWhere,
                                                 IOrderByExpression<TEntity>[] orderByExpressions, int pageSize, int pageIndex, out int totalPage, out int totalRecord,
                                                 bool isProxyCreationEnabled = false, bool asNoTracking = false)
        {
            //Context.Configuration.ProxyCreationEnabled = isProxyCreationEnabled; //是否使用代理模式

            totalRecord = funcWhere == null ? Context.Set<TEntity>().Count() : Context.Set<TEntity>().Where(funcWhere).Count();

            totalPage = Convert.ToInt32(Math.Ceiling((totalRecord + 0.0) / pageSize));

            return funcWhere == null
                ? ExpressionPager.ApplyOrder(Context.Set<TEntity>(), orderByExpressions).Skip(pageSize * (pageIndex - 1)).Take(
                    pageSize)
                : ExpressionPager.ApplyOrder(Context.Set<TEntity>(), orderByExpressions).Where(funcWhere).Skip(pageSize *
                                                                                                   (pageIndex - 1))
                      .Take(pageSize);
        }

        /// <summary>根据条件分页
        /// 
        /// </summary>
        /// <param name="funcWhere">查询条件</param>
        /// <param name="orderByExpressions">排序</param>
        /// <param name="isProxyCreationEnabled">是否代理</param>
        /// <param name="asNoTracking">是否追踪</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> PageQueryable(Expression<Func<TEntity, bool>> funcWhere,
                                                 IOrderByExpression<TEntity>[] orderByExpressions,
                                                 bool isProxyCreationEnabled = false, bool asNoTracking = false)
        {
           // Context.Configuration.ProxyCreationEnabled = isProxyCreationEnabled; //是否使用代理模式

            return funcWhere == null
                ? ExpressionPager.ApplyOrder(Context.Set<TEntity>(), orderByExpressions)
                : ExpressionPager.ApplyOrder(Context.Set<TEntity>(), orderByExpressions).Where(funcWhere);
        }

        #endregion

        #region 保存

        /// <summary>
        /// 保存,带泛型的快速操作方法以及查询操作不需要调用
        /// </summary>
        /// <returns></returns>
        public virtual int Save()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// 保存,带泛型的快速操作方法以及查询操作不需要调用
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }

        #endregion

  
    }
}
