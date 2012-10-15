using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbk.MobileApp.Model
{
    public class LocalizableEntity : BaseEntity
    {
        #region Primitive Properties

        public virtual string EntityName { get; set; }
        public virtual string PrimaryKeyFieldName { get; set; }

        #endregion

        #region Navigation Properties

        public virtual ICollection<LocalizableEntityTranslation> LocalizableEntityTranslation { get; set; }
      

        #endregion
   
    }
}
