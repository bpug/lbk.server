// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateFood.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Extensions;
    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class UpdateFood
    {
        #region - Constants and Fields -

        private readonly IFoodRepository _foodRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateFood(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateFoodCommand food)
        {
            try
            {
                this._foodRepository.Update(food.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateFoodExceptionMessage, ex);
            }
        }

        #endregion
    }
}
