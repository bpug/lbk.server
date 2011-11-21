// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class FoodPagedDataInputSpecification : Specification<Food>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Food> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public FoodPagedDataInputSpecification(PagedDataInput<Food> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Food, bool>> SatisfiedBy()
        {
            Specification<Food> specification = new TrueSpecification<Food>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (this._pagedDataInput.SearchItem.CategoryId > 0)
                {
                    specification &=
                        new DirectSpecification<Food>(p => p.CategoryId == this._pagedDataInput.SearchItem.CategoryId);
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Food>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.MenuId > 0)
                {
                    specification &=
                        new DirectSpecification<Food>(p => p.MenuId == this._pagedDataInput.SearchItem.MenuId);
                }

                if (this._pagedDataInput.SearchItem.Price != 0)
                {
                    specification &= new DirectSpecification<Food>(
                        p => p.Price == this._pagedDataInput.SearchItem.Price);
                }

                if (this._pagedDataInput.SearchItem.SortOrder != 0)
                {
                    specification &=
                        new DirectSpecification<Food>(p => p.SortOrder == this._pagedDataInput.SearchItem.SortOrder);
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Title))
                {
                    specification &=
                        new DirectSpecification<Food>(
                            p => p.Title.ToLower().Contains(this._pagedDataInput.SearchItem.Title.ToLower()));
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
