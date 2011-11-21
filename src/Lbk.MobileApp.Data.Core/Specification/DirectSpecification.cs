// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DirectSpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System;
    using System.Linq.Expressions;

    #endregion

    public sealed class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region - Constants and Fields -

        private readonly Expression<Func<TEntity, bool>> _matchingCriteria;

        #endregion

        #region - Constructors and Destructors -

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
            {
                throw new ArgumentNullException("matchingCriteria");
            }

            this._matchingCriteria = matchingCriteria;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return this._matchingCriteria;
        }

        #endregion
    }
}
