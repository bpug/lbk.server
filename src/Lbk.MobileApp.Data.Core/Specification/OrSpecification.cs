// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrSpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System;
    using System.Linq.Expressions;

    #endregion

    public sealed class OrSpecification<T> : CompositeSpecification<T>
        where T : class
    {
        #region - Constants and Fields -

        private readonly ISpecification<T> _leftSideSpecification;

        private readonly ISpecification<T> _rightSideSpecification;

        #endregion

        #region - Constructors and Destructors -

        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == null)
            {
                throw new ArgumentNullException("leftSide");
            }

            if (rightSide == null)
            {
                throw new ArgumentNullException("rightSide");
            }

            this._leftSideSpecification = leftSide;
            this._rightSideSpecification = rightSide;
        }

        #endregion

        #region - Properties -

        public override ISpecification<T> LeftSideSpecification
        {
            get
            {
                return this._leftSideSpecification;
            }
        }

        public override ISpecification<T> RightSideSpecification
        {
            get
            {
                return this._rightSideSpecification;
            }
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = this._leftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = this._rightSideSpecification.SatisfiedBy();

            return left.Or(right);
        }

        #endregion
    }
}
