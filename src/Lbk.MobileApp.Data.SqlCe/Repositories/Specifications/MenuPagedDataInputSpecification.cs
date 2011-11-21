// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuPagedDataInputSpecification.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Repositories.Specifications
{
    #region using directives

    using System;
    using System.Linq.Expressions;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data.Core.Specification;
    using Lbk.MobileApp.Model;

    #endregion

    public class MenuPagedDataInputSpecification : Specification<Menu>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Menu> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public MenuPagedDataInputSpecification(PagedDataInput<Menu> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Menu, bool>> SatisfiedBy()
        {
            Specification<Menu> specification = new TrueSpecification<Menu>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (this._pagedDataInput.SearchItem.Date > new DateTime(1900, 01, 01))
                {
                    specification &= new DirectSpecification<Menu>(p => p.Date == this._pagedDataInput.SearchItem.Date);
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Menu>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
