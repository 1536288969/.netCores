using System.Linq;

namespace Common.OrderByExpressions
{
    /// <summary>
    /// 多字段排序接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOrderByExpression<T>
    {
        IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> query);
        IOrderedQueryable<T> ApplyThenBy(IOrderedQueryable<T> query);
    }
}
