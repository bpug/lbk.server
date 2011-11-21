// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrueSpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System;
    using System.Linq.Expressions;

    #endregion

    public sealed class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region - Public Methods -

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            // Create "result variable" transform adhoc execution plan in prepared plan
            // for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
            const bool Result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => Result;
            return trueExpression;
        }

        #endregion
    }
}
