// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PicturePagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class PicturePagedDataInputSpecification : Specification<Picture>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Picture> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public PicturePagedDataInputSpecification(PagedDataInput<Picture> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Picture, bool>> SatisfiedBy()
        {
            Specification<Picture> specification = new TrueSpecification<Picture>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Picture>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.FileName))
                {
                    specification &=
                        new DirectSpecification<Picture>(
                            p => p.FileName.ToLower().Contains(this._pagedDataInput.SearchItem.FileName.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Link))
                {
                    specification &=
                        new DirectSpecification<Picture>(
                            p => p.Link.ToLower().Contains(this._pagedDataInput.SearchItem.Link.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.SortOrder != 0)
                {
                    specification &=
                        new DirectSpecification<Picture>(p => p.SortOrder == this._pagedDataInput.SearchItem.SortOrder);
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
