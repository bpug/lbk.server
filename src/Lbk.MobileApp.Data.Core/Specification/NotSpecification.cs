// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotSpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System;
    using System.Linq;
    using System.Linq.Expressions;

    #endregion

    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        #region - Constants and Fields -

        private readonly Expression<Func<TEntity, bool>> _originalCriteria;

        #endregion

        #region - Constructors and Destructors -

        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            this._originalCriteria = originalSpecification.SatisfiedBy();
        }

        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            if (originalSpecification == null)
            {
                throw new ArgumentNullException("originalSpecification");
            }

            this._originalCriteria = originalSpecification;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Not(this._originalCriteria.Body), this._originalCriteria.Parameters.Single());
        }

        #endregion
    }
}
