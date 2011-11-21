// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateSerieCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateSerieCommandExtensions
    {
        #region - Public Methods -

        public static Serie ToEntity(this ICreateSerieCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Serie
                {
                    ActivatedAt = source.ActivatedAt, 
                    Description = source.Description, 
                    ExpiresAt = source.ExpiresAt, 
                    Id = source.Id, 
                    IsActivated = source.IsActivated
                };
        }

        #endregion
    }
}
