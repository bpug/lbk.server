// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateEventCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateEventCommandExtensions
    {
        #region - Public Methods -

        public static Event ToEntity(this ICreateEventCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Event
                {
                    ActivatedAt = source.ActivatedAt, 
                    Date = source.Date, 
                    DateOrder = source.DateOrder, 
                    Description = source.Description, 
                    ExpiresAt = source.ExpiresAt, 
                    Id = source.Id, 
                    IsActivated = source.IsActivated, 
                    Title = source.Title
                };
        }

        #endregion
    }
}
