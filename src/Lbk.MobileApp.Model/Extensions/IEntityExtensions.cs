using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Lbk.MobileApp.Model.Attributes;

namespace Lbk.MobileApp.Model.Extensions
{
    public static class IEntityExtensions
    {
        public static List<PropertyInfo> GetTranslateProperties<T>(this T entity) where T : IEntity
        {
            //var props = new List<PropertyInfo>();
            //foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            //{
            //    foreach (TranslateAttribute attr in prop.GetCustomAttributes(typeof(TranslateAttribute), true))
            //    {
            //        if (attr.Translate == true)
            //        {
            //            props.Add(prop);
            //        }

            //    }
            //}

            return (from prop in typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance) 
                    from TranslateAttribute attr in prop.GetCustomAttributes(typeof (TranslateAttribute), true) where attr.Translate == true select prop).ToList();
        }
    }
}
