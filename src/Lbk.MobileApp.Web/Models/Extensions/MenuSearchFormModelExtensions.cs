// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuSearchFormModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using System;

    using Lbk.MobileApp.Model;

    #endregion

    public static class MenuSearchFormModelExtensions
    {
        #region - Public Methods -

        public static MenuSearchFormModel GetValueOrDefault(this MenuSearchFormModel item)
        {
            if (item == null
                ||
                ((!item.Date.HasValue || item.Date <= new DateTime(1900, 01, 01))
                 && string.IsNullOrWhiteSpace(item.Description)))
            {
                return null;
            }

            return item;
        }

        public static MenuFormModel ToFormModel(Menu model)
        {
            if (model == null)
            {
                return null;
            }

            return new MenuFormModel { Id = model.Id, Date = model.Date, Description = model.Description };
        }

        public static Menu ToModel(MenuSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Menu
                {
                    Id = model.Id, 
                    Date = model.Date.HasValue ? model.Date.Value : new DateTime(1900, 01, 01), 
                    Description = model.Description
                };
        }

        public static MenuSearchFormModel ToSearchFormModel(Menu model)
        {
            if (model == null)
            {
                return null;
            }

            return new MenuSearchFormModel
                {
                    Id = model.Id, 
                    Date = model.Date > new DateTime(1900, 01, 01) ? model.Date : new DateTime?(), 
                    Description = model.Description
                };
        }

        #endregion
    }
}
