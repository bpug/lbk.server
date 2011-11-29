// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteFoodById.cs" company="ip-connect GmbH">
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

    #endregion

    public class DeleteFoodById
    {
        #region - Constants and Fields -

        private readonly IFoodRepository _foodRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteFoodById(IFoodRepository foodRepository)
        {
            this._foodRepository = foodRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._foodRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteFoodExceptionMessage, ex);
            }
        }

        #endregion
    }
}
