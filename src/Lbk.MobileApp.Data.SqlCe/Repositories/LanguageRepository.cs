// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureRepository.cs" company="ip-connect GmbH">
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

    public class LanguageRepository : BaseRepository, ILanguageRepository
    {
        #region - Constructors and Destructors -

        public LanguageRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region ILanguageRepository

        public void Create(Language language)
        {
            this.GetDbSet<Language>().Add(language);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long languageId)
        {
            var entity = this.GetDbSet<Language>().Where(x => x.Id == languageId).Single();
            this.GetDbSet<Language>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Language GetLanguage(long languageId)
        {
            return this.GetDbSet<Language>().Where(x => x.Id == languageId).Single();
        }
       

        public void Update(Language language)
        {
            var entity = this.GetDbSet<Language>().Where(x => x.Id == language.Id).Single();

            entity.Code = language.Code;
            entity.Name = language.Name;
            entity.IsDefault = language.IsDefault;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
