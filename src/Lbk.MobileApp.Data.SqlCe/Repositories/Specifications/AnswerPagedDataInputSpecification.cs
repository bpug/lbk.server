// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class AnswerPagedDataInputSpecification : Specification<Answer>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<Answer> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public AnswerPagedDataInputSpecification(PagedDataInput<Answer> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<Answer, bool>> SatisfiedBy()
        {
            Specification<Answer> specification = new TrueSpecification<Answer>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Description))
                {
                    specification &=
                        new DirectSpecification<Answer>(
                            p => p.Description.ToLower().Contains(this._pagedDataInput.SearchItem.Description.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Explanation))
                {
                    specification &=
                        new DirectSpecification<Answer>(
                            p => p.Explanation.ToLower().Contains(this._pagedDataInput.SearchItem.Explanation.ToLower()));
                }

                ////specification &=
                ////    new DirectSpecification<Answer>(p => p.IsRight == this._pagedDataInput.SearchItem.IsRight);
                if (this._pagedDataInput.SearchItem.QuestionId > 0)
                {
                    specification &=
                        new DirectSpecification<Answer>(p => p.QuestionId == this._pagedDataInput.SearchItem.QuestionId);
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
