// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddFood.cs" company="ip-connect GmbH">
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

    public class AddFood
    {
        #region - Constants and Fields -

        private readonly IFoodRepository _foodRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddFood(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long menuId, long categoryId, ICreateFoodCommand food)
        {
            if (food == null)
            {
                throw new ArgumentNullException("food");
            }

            try
            {
                var entity = food.ToEntity();
                this._foodRepository.Create(menuId, categoryId, entity);

                food.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddFoodExceptionMessage, ex);
            }
        }

        #endregion
    }
}
