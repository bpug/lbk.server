// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionCategoryPagedDataInputSpecification.cs" company="ip-connect GmbH">
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

    public class QuestionCategoryPagedDataInputSpecification : Specification<QuestionCategory>
    {
        #region - Constants and Fields -

        private readonly PagedDataInput<QuestionCategory> _pagedDataInput;

        #endregion

        #region - Constructors and Destructors -

        public QuestionCategoryPagedDataInputSpecification(PagedDataInput<QuestionCategory> pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this._pagedDataInput = pagedDataInput;
        }

        #endregion

        #region - Public Methods -

        public override Expression<Func<QuestionCategory, bool>> SatisfiedBy()
        {
            Specification<QuestionCategory> specification = new TrueSpecification<QuestionCategory>();

            if (this._pagedDataInput.SearchItem != null)
            {
                if (!string.IsNullOrWhiteSpace(this._pagedDataInput.SearchItem.Title))
                {
                    specification &=
                        new DirectSpecification<QuestionCategory>(
                            p => p.Title.ToLower().Contains(this._pagedDataInput.SearchItem.Title.ToLower()));
                }
            }

            return specification.SatisfiedBy();
        }

        #endregion
    }
}
