// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System;
    using System.Linq.Expressions;

    #endregion

    public interface ISpecification<TEntity>
        where TEntity : class
    {
        #region - Public Methods -

        Expression<Func<TEntity, bool>> SatisfiedBy();

        #endregion
    }
}
