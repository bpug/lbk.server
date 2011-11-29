// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetFoodById.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class GetFoodById
    {
        #region - Constants and Fields -

        private readonly IFoodRepository _foodRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetFoodById(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Food Execute(long id)
        {
            try
            {
                return this._foodRepository.GetFood(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveFoodExceptionMessage, ex);
            }
        }

        #endregion
    }
}
