// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class EventPagedDataInputSpecification : Specification<Event>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Event> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public EventPagedDataInputSpecification(PagedDataInput<Event> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Event, bool>> SatisfiedBy()
        {
            Specification<Event> specification = new TrueSpecification<Event>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (this._pagedDataInput.SearchItem.ActivatedAt > new DateTime(1900, 01, 01))
                {
                    specification &=
                        new DirectSpecification<Event>(
                            p => p.ActivatedAt == this._pagedDataInput.SearchItem.ActivatedAt);
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Date))
                {
                    specification &=
                        new DirectSpecification<Event>(
                            p => p.Date.ToLower().Contains(this._pagedDataInput.SearchItem.Date.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.DateOrder > new DateTime(1900, 01, 01))
                {
                    specification &=
                        new DirectSpecification<Event>(p => p.DateOrder == this._pagedDataInput.SearchItem.DateOrder);
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Event>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.ExpiresAt > new DateTime(1900, 01, 01))
                {
                    specification &=
                        new DirectSpecification<Event>(p => p.ExpiresAt == this._pagedDataInput.SearchItem.ExpiresAt);
                }

                ////specification &=
                ////    new DirectSpecification<Event>(p => p.IsActivated == this._pagedDataInput.SearchItem.IsActivated);
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Title))
                {
                    specification &=
                        new DirectSpecification<Event>(
                            p => p.Title.ToLower().Contains(this._pagedDataInput.SearchItem.Title.ToLower()));
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
