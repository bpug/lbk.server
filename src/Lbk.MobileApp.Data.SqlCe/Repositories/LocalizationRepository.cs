using System;
using System.Data;
using System.Linq;
using System.Threading;
using Lbk.MobileApp.Model;
using Lbk.MobileApp.Model.Extensions;

namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    public class LocalizationRepository : BaseRepository, ILocalizationRepository
    {


        #region - Constructors and Destructors -

        public LocalizationRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        /// <summary>
        /// Translate an entity to a given language
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="languageCode">Optionally the language code.</param>
        /// <returns>The entity translated</returns>
        public T TranslateTo<T>( T entity, string languageCode = null) where T : IEntity
        {
            if (languageCode == null)
            {
                languageCode = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            }
            string entityName = entity.GetType().Name;
           
            // Get the entity info
            var locEntity = this.GetDbSet <LocalizableEntity>().FirstOrDefault(le => le.EntityName.Equals(entityName));
            if (null != locEntity)
            {
                // Get the entity id
                var entityId = (long)entity.GetType().GetProperty(locEntity.PrimaryKeyFieldName).GetValue(entity, null);
                // Get the  fields that need to be translated for this entity
                var ler = locEntity.LocalizableEntityTranslation
                            .Where(er => er.LocalizableEntity.EntityName.Equals(entityName)
                                            && er.PrimaryKeyValue.Equals(entityId)
                                            && er.Language.Code.Equals(languageCode));
                foreach (var t in ler)
                {
                    // Overwrite each field with the traslated value
                    entity.GetType().GetProperty(t.FieldName).SetValue(entity, t.Text, null);
                }
            }
            
            return entity;
        }

        public void Update<T>(T entity, string languageCode = null) where T : IEntity
        {
            if (languageCode == null)
            {
                languageCode = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            }

            string entityName = entity.GetType().Name;

             // Get the entity info
            var locEntity = this.GetDbSet<LocalizableEntity>().FirstOrDefault(le => le.EntityName.Equals(entityName));
            if (null != locEntity)
            {
               //var translations = locEntity.LocalizableEntityTranslation
                //            .Where(er => er.LocalizableEntity.EntityName.Equals(entityName)
                //                            && er.PrimaryKeyValue.Equals(entity.Id)
                //                            && er.Language.Code.Equals(languageCode));

                var lang = this.GetDbSet<Language>().FirstOrDefault(x => x.Code.Equals(languageCode));
                var props = entity.GetTranslateProperties();

                foreach (var prop in props)
                {
                    var @value = prop.GetValue(entity, null);
                    var translation = locEntity.LocalizableEntityTranslation
                                          .Where(er => er.LocalizableEntity.EntityName.Equals(entityName)
                                                       && er.PrimaryKeyValue.Equals(entity.Id)
                                                       && er.Language.Code.Equals(languageCode)
                                                       && er.FieldName.Equals(prop.Name)).SingleOrDefault() ??
                                      new LocalizableEntityTranslation();

                    translation.PrimaryKeyValue = entity.Id;
                    translation.LocalizableEntityId = locEntity.Id;
                    translation.LanguageId = lang.Id;
                    translation.Text = @value.ToString();
                    translation.FieldName = prop.Name;
                    if (translation.Id == 0)
                    {
                         this.GetDbSet<LocalizableEntityTranslation>().Add(translation);
                    }

                    this.SetEntityState(translation, translation.Id == 0 ? EntityState.Added : EntityState.Modified);
                }

               

                this.UnitOfWork.SaveChanges();
            }
        }

        public void Delete<T>(T entity) where T :  IEntity
        {
            string entityName = entity.GetType().Name;

            var entitys = this.GetDbSet<LocalizableEntityTranslation>()
                .Where(x => x.PrimaryKeyValue.Equals(entity.Id)
                    && x.LocalizableEntity.EntityName.Equals(entityName));

            foreach (var localizableEntityTranslation in entitys)
            {
                this.GetDbSet<LocalizableEntityTranslation>().Remove(localizableEntityTranslation);
            }


            this.UnitOfWork.SaveChanges();
        }

        public void Delete(Type type, long entityId)
        {
            string entityName = type.Name;

            var entitys = this.GetDbSet<LocalizableEntityTranslation>()
                .Where(x => x.PrimaryKeyValue.Equals(entityId)
                    && x.LocalizableEntity.EntityName.Equals(entityName));

            foreach (var localizableEntityTranslation in entitys)
            {
                this.GetDbSet<LocalizableEntityTranslation>().Remove(localizableEntityTranslation);
            }


            this.UnitOfWork.SaveChanges();
        }



        public Language GetDefaultLanguage()
        {
            return this.GetDbSet<Language>().Where(x => x.IsDefault == true).Single();
        }
    }  
}
