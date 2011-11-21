// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerRepository.cs" company="ip-connect GmbH">
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

    public class AnswerRepository : BaseRepository, IAnswerRepository
    {
        #region - Constructors and Destructors -

        public AnswerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IAnswerRepository

        public void Create(long questionId, Answer answer)
        {
            answer.QuestionId = questionId;
            this.GetDbSet<Answer>().Add(answer);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long answerId)
        {
            var entity = this.GetDbSet<Answer>().Where(x => x.Id == answerId).Single();
            this.GetDbSet<Answer>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Answer GetAnswer(long answerId)
        {
            return this.GetDbSet<Answer>().Include("Question").Where(x => x.Id == answerId).Single();
        }

        public PagedDataList<Answer> GetAnswers(PagedDataInput<Answer> pagedDataInput)
        {
            var specification = new AnswerPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Answer answer)
        {
            var entity = this.GetDbSet<Answer>().Where(x => x.Id == answer.Id).Single();

            entity.Description = answer.Description;
            entity.Explanation = answer.Explanation;
            entity.IsRight = answer.IsRight;
            entity.QuestionId = answer.QuestionId;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
