using System.Linq.Expressions;

namespace QuoteVibes.CrossCutting.Util
{
    public static class LinqExtensionsUtil
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string sortField, bool asc)
        {
            var param = Expression.Parameter(typeof(T), "p");
            var prop = Expression.Property(param, sortField);
            var exp = Expression.Lambda(prop, param);
            string method = asc ? "OrderBy" : "OrderByDescending";
            Type[] types = new Type[] { query.ElementType, exp.Body.Type };
            var mce = Expression.Call(typeof(Queryable), method, types, query.Expression, exp);
            return query.Provider.CreateQuery<T>(mce);
        }
    }
}
