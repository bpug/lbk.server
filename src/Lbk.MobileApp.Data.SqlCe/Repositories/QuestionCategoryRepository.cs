// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionCategoryRepository.cs" company="ip-connect GmbH">
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

    public class QuestionCategoryRepository : BaseRepository, IQuestionCategoryRepository
    {
        #region - Constructors and Destructors -

        public QuestionCategoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region ICategoryRepository

        public void Create(QuestionCategory category)
        {
            this.GetDbSet<QuestionCategory>().Add(category);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long categoryId)
        {
            var entity = this.GetDbSet<QuestionCategory>().Where(x => x.Id == categoryId).Single();
            this.GetDbSet<QuestionCategory>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public PagedDataList<QuestionCategory> GetCategories(PagedDataInput<QuestionCategory> pagedDataInput)
        {
            var specification = new QuestionCategoryPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public QuestionCategory GetCategory(long categoryId)
        {
            return this.GetDbSet<QuestionCategory>().Where(x => x.Id == categoryId).Single();
        }

        public void Update(QuestionCategory category)
        {
            var entity = this.GetDbSet<QuestionCategory>().Where(x => x.Id == category.Id).Single();
           
            entity.Title = category.Title;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
