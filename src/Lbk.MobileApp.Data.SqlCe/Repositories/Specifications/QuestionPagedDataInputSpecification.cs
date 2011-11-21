// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class QuestionPagedDataInputSpecification : Specification<Question>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Question> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public QuestionPagedDataInputSpecification(PagedDataInput<Question> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Question, bool>> SatisfiedBy()
        {
            Specification<Question> specification = new TrueSpecification<Question>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Question>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (this._pagedDataInput.SearchItem.Number > 0)
                {
                    specification &=
                        new DirectSpecification<Question>(p => p.Number == this._pagedDataInput.SearchItem.Number);
                }

                if (this._pagedDataInput.SearchItem.Points > 0)
                {
                    specification &=
                        new DirectSpecification<Question>(p => p.Points == this._pagedDataInput.SearchItem.Points);
                }

                if (this._pagedDataInput.SearchItem.SerieId > 0)
                {
                    specification &=
                        new DirectSpecification<Question>(p => p.SerieId == this._pagedDataInput.SearchItem.SerieId);
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
