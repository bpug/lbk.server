// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using System;

    using Lbk.MobileApp.Model;

    #endregion

    public static class EventModelExtensions
    {
        #region - Public Methods -

        public static EventSearchFormModel GetValueOrDefault(this EventSearchFormModel item)
        {
            if (item == null
                ||
                ((!item.ActivatedAt.HasValue || item.ActivatedAt <= new DateTime(1900, 01, 01))
                 && (!item.ExpiresAt.HasValue || item.ExpiresAt <= new DateTime(1900, 01, 01))
                 && string.IsNullOrWhiteSpace(item.Title) && string.IsNullOrWhiteSpace(item.Description)))
            {
                return null;
            }

            return item;
        }

        public static EventFormModel ToFormModel(Event model)
        {
            if (model == null)
            {
                return null;
            }

            return new EventFormModel
                {
                    ActivatedAt = model.ActivatedAt, 
                    Date = model.Date, 
                    DateOrder = model.DateOrder, 
                    Description = model.Description, 
                    ExpiresAt = model.ExpiresAt, 
                    Id = model.Id, 
                    IsActivated = model.IsActivated, 
                    Title = model.Title
                };
        }

        public static Event ToModel(EventSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Event
                {
                    ActivatedAt = model.ActivatedAt.HasValue ? model.ActivatedAt.Value : new DateTime(1900, 01, 01), 
                    Description = model.Description, 
                    ExpiresAt = model.ExpiresAt.HasValue ? model.ExpiresAt.Value : new DateTime(1900, 01, 01), 
                    Id = model.Id, 
                    Title = model.Title
                };
        }

        public static EventSearchFormModel ToSearchFormModel(Event model)
        {
            if (model == null)
            {
                return null;
            }

            return new EventSearchFormModel
                {
                    ActivatedAt = model.ActivatedAt > new DateTime(1900, 01, 01) ? model.ActivatedAt : new DateTime?(), 
                    ExpiresAt = model.ExpiresAt > new DateTime(1900, 01, 01) ? model.ExpiresAt : new DateTime?(), 
                    Description = model.Description, 
                    Id = model.Id, 
                    Title = model.Title
                };
        }

        #endregion
    }
}
