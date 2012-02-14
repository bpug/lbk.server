// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class VideoPagedDataInputSpecification : Specification<Video>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Video> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public VideoPagedDataInputSpecification(PagedDataInput<Video> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Video, bool>> SatisfiedBy()
        {
            Specification<Video> specification = new TrueSpecification<Video>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Video>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.FileName))
                {
                    specification &=
                        new DirectSpecification<Video>(
                            p => p.FileName.ToLower().Contains(this._pagedDataInput.SearchItem.FileName.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Link))
                {
                    specification &=
                        new DirectSpecification<Video>(
                            p => p.Link.ToLower().Contains(this._pagedDataInput.SearchItem.Link.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.SortOrder != 0)
                {
                    specification &=
                        new DirectSpecification<Video>(p => p.SortOrder == this._pagedDataInput.SearchItem.SortOrder);
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
