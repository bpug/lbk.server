// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeriePagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class SeriePagedDataInputSpecification : Specification<Serie>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Serie> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public SeriePagedDataInputSpecification(PagedDataInput<Serie> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Serie, bool>> SatisfiedBy()
        {
            Specification<Serie> specification = new TrueSpecification<Serie>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (this._pagedDataInput.SearchItem.ActivatedAt > new DateTime(1900, 01, 01))
                {
                    specification &=
                        new DirectSpecification<Serie>(
                            p => p.ActivatedAt == this._pagedDataInput.SearchItem.ActivatedAt);
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Serie>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.ExpiresAt > new DateTime(1900, 01, 01))
                {
                    specification &=
                        new DirectSpecification<Serie>(p => p.ExpiresAt == this._pagedDataInput.SearchItem.ExpiresAt);
                }

                ////specification &=
                ////    new DirectSpecification<Serie>(p => p.IsActivated == this._pagedDataInput.SearchItem.IsActivated);
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
