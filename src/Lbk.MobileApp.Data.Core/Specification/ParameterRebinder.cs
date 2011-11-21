// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterRebinder.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core.Specification
{
    #region using directives

    using System.Collections.Generic;
    using System.Linq.Expressions;

    #endregion

    public sealed class ParameterRebinder : ExpressionVisitor
    {
        #region - Constants and Fields -

        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        #endregion

        #region - Constructors and Destructors -

        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this._map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        #endregion

        #region - Public Methods -

        public static Expression ReplaceParameters(
            Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        #endregion

        #region - Methods -

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (this._map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }

            return base.VisitParameter(p);
        }

        #endregion
    }
}
