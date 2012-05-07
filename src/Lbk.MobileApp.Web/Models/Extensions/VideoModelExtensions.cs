// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class VideoModelExtensions
    {
        #region - Public Methods -

        public static VideoSearchFormModel GetValueOrDefault(this VideoSearchFormModel item)
        {
            if (item == null
                ||
                (string.IsNullOrWhiteSpace(item.Description) && string.IsNullOrWhiteSpace(item.FileName)
                 && string.IsNullOrWhiteSpace(item.Link)))
            {
                return null;
            }

            return item;
        }

        public static VideoFormModel ToFormModel(this Video model)
        {
            if (model == null)
            {
                return null;
            }

            return new VideoFormModel
                       {
                           Description = model.Description, 
                           FileName = model.FileName, 
                           Id = model.Id, 
                           Link = model.Link, 
                           SortOrder = model.SortOrder, 
                           ThumbnailLink = model.ThumbnailLink
                       };
        }

        public static Video ToModel(this VideoSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Video
                       {
                          Description = model.Description, FileName = model.FileName, Id = model.Id, Link = model.Link 
                       };
        }

        public static VideoSearchFormModel ToSearchFormModel(this Video model)
        {
            if (model == null)
            {
                return null;
            }

            return new VideoSearchFormModel
                       {
                          Description = model.Description, FileName = model.FileName, Id = model.Id, Link = model.Link 
                       };
        }

        #endregion
    }
}
