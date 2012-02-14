// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateVideoCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateVideoCommandExtensions
    {
        #region - Public Methods -

        public static Video ToEntity(this ICreateVideoCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Video
                       {
                           Description = source.Description, 
                           FileName = source.FileName, 
                           Id = source.Id, 
                           Link = source.Link, 
                           SortOrder = source.SortOrder, 
                           ThumbnailLink = source.ThumbnailLink
                       };
        }

        #endregion
    }
}
