// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompositeSpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region - Properties -

        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        public abstract ISpecification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}
