// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreatePictureCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreatePictureCommandExtensions
    {
        #region - Public Methods -

        public static Picture ToEntity(this ICreatePictureCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Picture
                       {
                           Description = source.Description, 
                           FileName = source.FileName, 
                           Id = source.Id, 
                           Link = source.Link, 
                           SortOrder = source.SortOrder
                       };
        }

        #endregion
    }
}
