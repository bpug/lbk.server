// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICategoryRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface ICategoryRepository
    {
        #region - Public Methods -

        void Create(Category category);

        void Delete(long categoryId);

        PagedDataList<Category> GetCategories(PagedDataInput<Category> pagedDataInput);

        Category GetCategory(long categoryId);

        void Update(Category category);

        #endregion
    }
}
