// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetFoods.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class GetFoods
    {
        #region - Constants and Fields -

        private readonly IFoodRepository _foodRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetFoods(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Food> Execute(PagedDataInput<Food> pagedDataInput)
        {
            try
            {
                return this._foodRepository.GetFoods(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveFoodExceptionMessage, ex);
            }
        }

        #endregion
    }
}
