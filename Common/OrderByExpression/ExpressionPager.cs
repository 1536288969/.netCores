using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.OrderByExpressions
{
    public class ExpressionPager
    {
        /// <summary>
        /// 应用排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="property">分类字段</param>
        /// <param name="isAscdening">是否升序</param>
        /// <returns></returns>
        public static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, bool isAscdening)
        {
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            var pi = type.GetProperty(property);
            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            object result;
            if (isAscdening)
            {
                result = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderBy" && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2 && method.GetParameters().Length == 2).
                    MakeGenericMethod(typeof(T), type).Invoke(null, new object[] { source, lambda });
            }
            else
            {
                result = typeof(Queryable).GetMethods().Single(method => method.Name == "OrderByDescending" && method.IsGenericMethodDefinition
                        && method.GetGenericArguments().Length == 2 && method.GetParameters().Length == 2).
                    MakeGenericMethod(typeof(T), type).Invoke(null, new object[] { source, lambda });
            }
            return (IOrderedQueryable<T>)result;
        }

        /// <summary>
        /// 应用多字段排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="orderByExpressions"></param>
        /// <returns></returns>
        public static IQueryable<T> ApplyOrder<T>(IQueryable<T> query, params IOrderByExpression<T>[] orderByExpressions) where T : class
        {
            if (orderByExpressions == null)
                return query;

            IOrderedQueryable<T> output = null;

            foreach (var orderByExpression in orderByExpressions)
            {
                output = output == null ? orderByExpression.ApplyOrderBy(query) : orderByExpression.ApplyThenBy(output);
            }

            return output ?? query;
        }
    }
}
