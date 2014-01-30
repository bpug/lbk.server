// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvExport.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Lbk.MobileApp.Core.Extensions;
    using Lbk.MobileApp.Model.Attributes;

    public class CsvExport<T> : CsvExportBase
        where T : class
    {
        private readonly IEnumerable<T> objects;

        public CsvExport(IEnumerable<T> objects)
        {
            this.objects = objects;
        }

        public override string Export(bool includeHeaderLine)
        {
            var propertyInfos = typeof(T).GetProperties();
            var sb = new StringBuilder();
            this.SetTitle(sb);
            if (includeHeaderLine)
            {
                sb.AppendLine(this.GetCsvHeaderSorted(propertyInfos));
            }

            this.objects.ForEach(d => sb.AppendLine(this.GetCsvDataRowSorted(d, propertyInfos)));
            return sb.ToString();
        }

        protected string GetCsvDataRowSorted(T csvDataObject, IEnumerable<PropertyInfo> propertyInfos)
        {
            var valuesSorted = propertyInfos.Select(
                x => new
                {
                    Value = x.GetValue(csvDataObject, null),
                    Attribute =
                     (ExportColumnAttribute)Attribute.GetCustomAttribute(x, typeof(ExportColumnAttribute), false)
                }).Where(x => x.Attribute != null && x.Attribute.Export).OrderBy(x => x.Attribute.Order).Select(
                        x => this.MakeValueCsvFriendly(x.Value));
            return string.Join(this.Separator, valuesSorted);
        }

        protected virtual string GetCsvHeaderSorted(IEnumerable<PropertyInfo> propertyInfos)
        {
            // var headersSorted =
            // propertyInfos.Select(
            // x => (CsvColumnAttribute)Attribute.GetCustomAttribute(x, typeof(CsvColumnAttribute), false) ?? new CsvColumnAttribute()).Where(
            // x => x != null && x.Export).OrderBy(x => x.Order).Select(x => x.Name);
            var headersSorted = propertyInfos.Select(
                n => new
                {
                    n.Name,
                    CsvColumnAttribute =
                     (ExportColumnAttribute)Attribute.GetCustomAttribute(n, typeof(ExportColumnAttribute), false)
                     ?? new ExportColumnAttribute()
                }).Select(
                        e => new
                        {
                            Value = e.CsvColumnAttribute.Name ?? e.Name,
                            e.CsvColumnAttribute.Order,
                            e.CsvColumnAttribute.Export
                        }).Where(x => x != null && x.Export).OrderBy(x => x.Order).Select(x => x.Value);

            return string.Join(this.Separator, headersSorted);
        }
    }
}