using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.OrderByExpressions
{
    /// <summary>
    /// 多字段排序
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TOrderByFieldType"></typeparam>
    public class OrderByExpression<TEntity, TOrderByFieldType> : IOrderByExpression<TEntity> where TEntity : class
    {
        private readonly Expression<Func<TEntity, TOrderByFieldType>> _expression;
        private readonly bool _descending;

        public OrderByExpression(Expression<Func<TEntity, TOrderByFieldType>> expression,
            bool descending = false)
        {
            _expression = expression;
            _descending = descending;
        }

        public IOrderedQueryable<TEntity> ApplyOrderBy(
            IQueryable<TEntity> query)
        {
            return _descending ? query.OrderByDescending(_expression) : query.OrderBy(_expression);
        }

        public IOrderedQueryable<TEntity> ApplyThenBy(
            IOrderedQueryable<TEntity> query)
        {
            return _descending ? query.ThenByDescending(_expression) : query.ThenBy(_expression);
        }
    }
}
