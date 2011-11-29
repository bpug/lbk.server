// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodSearchFormModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using System.Collections.Generic;
    using System.Linq;

    using Lbk.MobileApp.Model;

    #endregion

    public static class FoodSearchFormModelExtensions
    {
        #region - Public Methods -

        public static FoodSearchFormModel GetValueOrDefault(this FoodSearchFormModel item)
        {
            if (item == null || (string.IsNullOrWhiteSpace(item.Title) && string.IsNullOrWhiteSpace(item.Description)))
            {
                return null;
            }

            return item;
        }

        public static FoodListViewModel ToFoodListViewModel(Food model)
        {
            if (model == null)
            {
                return null;
            }

            return new FoodListViewModel
                {
                    Category = model.Category, 
                    CategoryId = model.CategoryId, 
                    Description = model.Description, 
                    Id = model.Id, 
                    Menu = model.Menu, 
                    MenuId = model.MenuId, 
                    Price = model.Price, 
                    SortOrder = model.SortOrder, 
                    Title = model.Title
                };
        }

        public static IEnumerable<FoodListViewModel> ToFoodListViewModels(IEnumerable<Food> models)
        {
            return models.Select(ToFoodListViewModel);
        }

        public static FoodFormModel ToFormModel(Food model)
        {
            if (model == null)
            {
                return null;
            }

            return new FoodFormModel
                {
                    Id = model.Id, 
                    CategoryId = model.CategoryId, 
                    CategoryName = model.Category != null ? model.Category.GetCategoryCompleteDescription() : null, 
                    Description = model.Description, 
                    MenuId = model.MenuId, 
                    Price = model.Price, 
                    SortOrder = model.SortOrder, 
                    Title = model.Title
                };
        }

        public static Food ToModel(FoodSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Food
                {
                    Id = model.Id, 
                    CategoryId = model.CategoryId, 
                    Description = model.Description, 
                    MenuId = model.MenuId, 
                    Title = model.Title
                };
        }

        public static FoodSearchFormModel ToSearchFormModel(Food model)
        {
            if (model == null)
            {
                return null;
            }

            return new FoodSearchFormModel
                {
                    Id = model.Id, 
                    CategoryId = model.CategoryId, 
                    Description = model.Description, 
                    MenuId = model.MenuId, 
                    Title = model.Title
                };
        }

        #endregion
    }
}
