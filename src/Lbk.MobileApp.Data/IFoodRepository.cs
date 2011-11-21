// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFoodRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IFoodRepository
    {
        #region - Public Methods -

        void Create(long menuId, long categoryId, Food food);

        void Delete(long foodId);

        Food GetFood(long foodId);

        PagedDataList<Food> GetFoods(PagedDataInput<Food> pagedDataInput);

        void Update(Food food);

        #endregion
    }
}
