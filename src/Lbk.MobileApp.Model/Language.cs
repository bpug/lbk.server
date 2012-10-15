using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbk.MobileApp.Model
{
    public class Language : BaseEntity
    {
        #region Primitive Properties

        public string Code { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        #endregion

        #region Navigation Properties

        public  ICollection<LocalizableEntityTranslation> LocalizableEntityTranslation { get; set; }

        #endregion
     
    }
}
