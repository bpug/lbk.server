// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Specification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System;
    using System.Linq.Expressions;

    #endregion

    public abstract class Specification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        #region - Operators -

        public static Specification<TEntity> operator &(
            Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
        {
            return new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        public static Specification<TEntity> operator |(
            Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
        {
            return new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);
        }

        public static bool operator false(Specification<TEntity> specification)
        {
            return false;
        }

        public static Specification<TEntity> operator !(Specification<TEntity> specification)
        {
            return new NotSpecification<TEntity>(specification);
        }

        public static bool operator true(Specification<TEntity> specification)
        {
            return false;
        }

        #endregion

        #region - Implemented Interfaces -

        #region ISpecification<TEntity>

        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();

        #endregion

        #endregion
    }
}
