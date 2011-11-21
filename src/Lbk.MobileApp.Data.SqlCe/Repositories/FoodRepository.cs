// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodRepository.cs" company="ip-connect GmbH">
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

    public class FoodRepository : BaseRepository, IFoodRepository
    {
        #region - Constructors and Destructors -

        public FoodRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IFoodRepository

        public void Create(long menuId, long categoryId, Food food)
        {
            food.MenuId = menuId;
            food.CategoryId = categoryId;
            this.GetDbSet<Food>().Add(food);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long foodId)
        {
            var entity = this.GetDbSet<Food>().Where(x => x.Id == foodId).Single();
            this.GetDbSet<Food>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Food GetFood(long foodId)
        {
            return this.GetDbSet<Food>().Include("Menu").Include("Category").Where(x => x.Id == foodId).Single();
        }

        public PagedDataList<Food> GetFoods(PagedDataInput<Food> pagedDataInput)
        {
            var specification = new FoodPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Food food)
        {
            var entity = this.GetDbSet<Food>().Where(x => x.Id == food.Id).Single();

            entity.CategoryId = food.CategoryId;
            entity.Description = food.Description;
            entity.MenuId = food.MenuId;
            entity.Price = food.Price;
            entity.SortOrder = food.SortOrder;
            entity.Title = food.Title;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
