using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbk.MobileApp.Model
{
    public class LocalizableEntityTranslation : BaseEntity
    {
        #region Primitive Properties

         public virtual long PrimaryKeyValue { get; set; }
         public virtual string FieldName { get; set; }
         public virtual string Text { get; set; }

         public virtual long LocalizableEntityId { get; set; }
         public virtual long LanguageId { get; set; }

        #endregion

        #region Navigation Properties

         public virtual Language Language { get; set; }
         public virtual LocalizableEntity LocalizableEntity { get; set; }
        #endregion
        
    }
}
