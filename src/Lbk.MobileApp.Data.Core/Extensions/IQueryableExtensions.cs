// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryableExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Extensions
{
    #region using directives

    using System.Linq;
    using System.Linq.Expressions;

    #endregion

    public static class IQueryableExtensions
    {
        #region - Public Methods -

        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(
                typeof(Queryable), 
                "OrderBy", 
                new[] { type, property.PropertyType }, 
                queryable.Expression, 
                Expression.Quote(orderByExp));

            return queryable.Provider.CreateQuery<T>(resultExp);
        }

        public static IQueryable<T> OrderByDescending<T>(
            this IQueryable<T> queryable, string ordering, params object[] values)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(
                typeof(Queryable), 
                "OrderByDescending", 
                new[] { type, property.PropertyType }, 
                queryable.Expression, 
                Expression.Quote(orderByExp));

            return queryable.Provider.CreateQuery<T>(resultExp);
        }

        #endregion
    }
}
