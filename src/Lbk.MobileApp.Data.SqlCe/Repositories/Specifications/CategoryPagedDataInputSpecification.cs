// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class CategoryPagedDataInputSpecification : Specification<Category>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Category> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public CategoryPagedDataInputSpecification(PagedDataInput<Category> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Category, bool>> SatisfiedBy()
        {
            Specification<Category> specification = new TrueSpecification<Category>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Category>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Title))
                {
                    specification &=
                        new DirectSpecification<Category>(
                            p => p.Title.ToLower().Contains(this._pagedDataInput.SearchItem.Title.ToLower()));
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
