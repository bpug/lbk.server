// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    #region using directives

    using System.Data;
    using System.Linq;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data.Core;
    using Lbk.MobileApp.Data.SqlCe.Repositories.Specifications;
    using Lbk.MobileApp.Model;

    #endregion

    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        #region - Constructors and Destructors -

        public CategoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region ICategoryRepository

        public void Create(Category category)
        {
            this.GetDbSet<Category>().Add(category);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long categoryId)
        {
            var entity = this.GetDbSet<Category>().Where(x => x.Id == categoryId).Single();
            this.GetDbSet<Category>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public PagedDataList<Category> GetCategories(PagedDataInput<Category> pagedDataInput)
        {
            var specification = new CategoryPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public Category GetCategory(long categoryId)
        {
            return this.GetDbSet<Category>().Include("Foods").Where(x => x.Id == categoryId).Single();
        }

        public void Update(Category category)
        {
            var entity = this.GetDbSet<Category>().Where(x => x.Id == category.Id).Single();

            entity.Description = category.Description;
            entity.Title = category.Title;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
