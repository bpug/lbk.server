// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class PictureModelExtensions
    {
        #region - Public Methods -

        public static PictureSearchFormModel GetValueOrDefault(this PictureSearchFormModel item)
        {
            if (item == null
                ||
                (string.IsNullOrWhiteSpace(item.Description) && string.IsNullOrWhiteSpace(item.Title)  && string.IsNullOrWhiteSpace(item.FileName)
                 && string.IsNullOrWhiteSpace(item.Link)))
            {
                return null;
            }

            return item;
        }

        public static PictureFormModel ToFormModel(Picture model)
        {
            if (model == null)
            {
                return null;
            }

            return new PictureFormModel
                       {
                           Title = model.Title,
                           Description = model.Description, 
                           FileName = model.FileName, 
                           Id = model.Id, 
                           Link = model.Link, 
                           SortOrder = model.SortOrder
                       };
        }

        public static Picture ToModel(PictureSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Picture
                       {
                          Title= model.Title, Description = model.Description, FileName = model.FileName, Id = model.Id, Link = model.Link 
                       };
        }

        public static PictureSearchFormModel ToSearchFormModel(Picture model)
        {
            if (model == null)
            {
                return null;
            }

            return new PictureSearchFormModel
                       {
                           Title = model.Title,
                           Description = model.Description,
                           FileName = model.FileName,
                           Id = model.Id,
                           Link = model.Link 
                       };
        }

        #endregion
    }
}
