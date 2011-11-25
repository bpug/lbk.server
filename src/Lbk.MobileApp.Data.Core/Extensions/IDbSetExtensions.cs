// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDbSetExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Extensions
{
    #region using directives

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    #endregion

    public static class IDbSetExtensions
    {
        #region - Public Methods -

        public static IQueryable<TEntity> Include<TEntity, TProperty>(
            this IDbSet<TEntity> dbSet, Expression<Func<TEntity, TProperty>> path) where TEntity : class
        {
            var objectQuery = dbSet as DbQuery<TEntity>;
            if (objectQuery != null)
            {
                return objectQuery.Include(path);
            }

            return dbSet;
        }

        public static IQueryable<TEntity> Includes<TEntity, TProperty>(
            this IDbSet<TEntity> dbSet, params Expression<Func<TEntity, TProperty>>[] paths) where TEntity : class
        {
            var objectQuery = dbSet as DbQuery<TEntity>;
            if (objectQuery != null)
            {
                if (paths != null)
                {
                    IQueryable<TEntity> queryable = dbSet;

                    foreach (var path in paths)
                    {
                        queryable = dbSet.Include(path);
                    }

                    return queryable;
                }
            }

            return dbSet;
        }

        #endregion
    }
}
