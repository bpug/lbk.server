// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerieSearchFormModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using System;

    using Lbk.MobileApp.Model;

    #endregion

    public static class SerieSearchFormModelExtensions
    {
        #region - Public Methods -

        public static SerieSearchFormModel GetValueOrDefault(this SerieSearchFormModel item)
        {
            if (item == null
                ||
                ((!item.ActivatedAt.HasValue || item.ActivatedAt <= new DateTime(1900, 01, 01))
                 && string.IsNullOrWhiteSpace(item.Description)
                 && (!item.ExpiresAt.HasValue || item.ExpiresAt <= new DateTime(1900, 01, 01))))
            {
                return null;
            }

            return item;
        }

        public static SerieFormModel ToFormModel(Serie model)
        {
            if (model == null)
            {
                return null;
            }

            return new SerieFormModel
                {
                    Id = model.Id, 
                    ActivatedAt = model.ActivatedAt, 
                    Description = model.Description, 
                    ExpiresAt = model.ExpiresAt, 
                    IsActivated = model.IsActivated
                };
        }

        public static Serie ToModel(SerieSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Serie
                {
                    Id = model.Id, 
                    ActivatedAt = model.ActivatedAt.HasValue ? model.ActivatedAt.Value : new DateTime(1900, 01, 01), 
                    Description = model.Description, 
                    ExpiresAt = model.ExpiresAt.HasValue ? model.ExpiresAt.Value : new DateTime(1900, 01, 01)
                };
        }

        public static SerieSearchFormModel ToSearchFormModel(Serie model)
        {
            if (model == null)
            {
                return null;
            }

            return new SerieSearchFormModel
                {
                    Id = model.Id, 
                    ActivatedAt = model.ActivatedAt > new DateTime(1900, 01, 01) ? model.ActivatedAt : new DateTime?(), 
                    Description = model.Description, 
                    ExpiresAt = model.ExpiresAt > new DateTime(1900, 01, 01) ? model.ExpiresAt : new DateTime?()
                };
        }

        #endregion
    }
}
