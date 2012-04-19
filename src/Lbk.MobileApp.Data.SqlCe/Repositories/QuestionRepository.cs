// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    #region using directives

    using System.Data;
    using System.Data.Entity;
    using System.Linq;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data.Core;
    using Lbk.MobileApp.Data.Core.Extensions;
    using Lbk.MobileApp.Data.SqlCe.Repositories.Specifications;
    using Lbk.MobileApp.Model;

    #endregion

    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        #region - Constructors and Destructors -

        public QuestionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IQuestionRepository

        public void Create(long serieId, long categoryId, Question question)
        {
            question.CategoryId = categoryId;
            question.SerieId = serieId;
            this.GetDbSet<Question>().Add(question);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long questionId)
        {
            var entity = this.GetDbSet<Question>().Where(x => x.Id == questionId).Single();
            this.GetDbSet<Question>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Question GetQuestion(long questionId)
        {
            return this.GetDbSet<Question>().Include("Answers").Include(x => x.Category).Where(x => x.Id == questionId).Single();
        }

        public PagedDataList<Question> GetQuestions(PagedDataInput<Question> pagedDataInput)
        {
            var specification = new QuestionPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification,
                x => x.Category);
        }

        public void Update(Question question)
        {
            var entity = this.GetDbSet<Question>().Where(x => x.Id == question.Id).Single();

            entity.CategoryId = question.CategoryId;
            entity.Description = question.Description;
            entity.Number = question.Number;
            entity.Points = question.Points;
            entity.SerieId = question.SerieId;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
