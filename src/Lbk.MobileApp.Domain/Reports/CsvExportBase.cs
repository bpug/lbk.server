// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvExportBase.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Reports
{
    using System;
    using System.Data.SqlTypes;
    using System.IO;
    using System.Text;

    public abstract class CsvExportBase
    {
        private string separator = ";";

        public string Separator
        {
            get
            {
                return this.separator;
            }

            set
            {
                this.separator = value;
            }
        }

        public string Title { get; set; }

        public string Export()
        {
            return this.Export(true);
        }

        public abstract string Export(bool includeHeaderLine);

        public byte[] ExportToBytes(Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }

            return encoding.GetBytes(this.Export());
        }

        public void ExportToFile(string path)
        {
            File.WriteAllText(path, this.Export());
        }

        protected string MakeValueCsvFriendly(object propertyValue)
        {
            if (propertyValue == null)
            {
                return string.Empty;
            }

            if (propertyValue is INullable && ((INullable)propertyValue).IsNull)
            {
                return string.Empty;
            }

            if (propertyValue is DateTime)
            {
                return ((DateTime)propertyValue).ToString("dd MMM yyyy");
            }

            // if (propertyValue is int)
            // {
            // return propertyValue.ToString();
            // }
            if (propertyValue is float)
            {
                return ((float)propertyValue).ToString("#.####");
            }

            if (propertyValue is double)
            {
                return ((double)propertyValue).ToString("#.####");
            }

            var output = "\"" + propertyValue.ToString().Replace("\"", "\"\"") + "\""; // quotes with 2 quotes

            return output;
        }

        protected void SetTitle(StringBuilder sb)
        {
            if (string.IsNullOrEmpty(this.Title))
            {
                return;
            }

            // escape chars that would otherwise break the row / export
            var csvTokens = new[]
                {
                    '\"', ',', '\n', '\r'
                };

            var title = this.Title.Split(
                new[]
                    {
                        "\n"
                    },
                StringSplitOptions.None);
            foreach (string s in title)
            {
                string tmp = s;
                if (this.Title.IndexOfAny(csvTokens) >= 0)
                {
                    tmp = "\"" + tmp.Replace("\"", "\"\"") + "\"";
                }

                sb.Append(tmp).Append(this.Separator);
                sb.AppendLine();
            }

            sb.AppendLine();
        }

        //private string 
    }
}