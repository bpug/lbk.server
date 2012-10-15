using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Lbk.MobileApp.Model;

namespace Lbk.MobileApp.Data.SqlCe
{
    public static class Localization
    {
        /// <summary>
        /// Translate an entity to a given language
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity</param>
        /// <param name="languageCode">Optionally the language code.</param>
        /// <returns>The entity translated</returns>
        public static T TranslateTo<T>(this T entity, string languageCode = null) where T : IEntity
        {
            if (languageCode == null)
            {
                languageCode = Thread.CurrentThread.CurrentCulture.IetfLanguageTag;
            }


            //string entityName = entity.GetType().BaseType.Name;
            string entityName = entity.GetType().Name;
            using (var ctx = new MobileAppDbContext())
            {

                var @defaultLang = ctx.Languages.Where(p => p.IsDefault == true).Single();
                if (@defaultLang.Code == languageCode)
                {
                    return entity;
                }
                
                // Get the entity info
                LocalizableEntity locEntity = ctx.LocalizableEntitys.FirstOrDefault(le => le.EntityName.Equals(entityName));
                if (null != locEntity)
                {
                    // Get the entity id
                    long entityId = (long)entity.GetType().GetProperty(locEntity.PrimaryKeyFieldName).GetValue(entity, null);
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
            }
            return entity;
        }
    }  



}
