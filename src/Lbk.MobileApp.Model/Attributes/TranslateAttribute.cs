using System;

namespace Lbk.MobileApp.Model.Attributes
{
   [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
   public class TranslateAttribute : Attribute
    {
       public  bool Translate;

       public TranslateAttribute()
       {
           this.Translate = true;
       }

       public TranslateAttribute(bool translate)
       {
           this.Translate = translate;
       }
    }
}
