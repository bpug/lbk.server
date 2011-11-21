// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SqlCeInitializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Initializers
{
    #region using directives

    using System;
    using System.Data.Entity;
    using System.Data.SqlServerCe;
    using System.IO;

    #endregion

    internal abstract class SqlCeInitializer<T> : IDatabaseInitializer<T>
        where T : DbContext
    {
        #region - Implemented Interfaces -

        #region IDatabaseInitializer<T>

        public abstract void InitializeDatabase(T context);

        #endregion

        #endregion

        #region - Methods -

        protected static DbContext ReplaceSqlCeConnection(DbContext context)
        {
            if (context.Database.Connection is SqlCeConnection)
            {
                SqlCeConnectionStringBuilder builder =
                    new SqlCeConnectionStringBuilder(context.Database.Connection.ConnectionString);
                if (!string.IsNullOrWhiteSpace(builder.DataSource))
                {
                    builder.DataSource = ReplaceDataDirectory(builder.DataSource);
                    return new DbContext(builder.ConnectionString);
                }
            }

            return context;
        }

        protected virtual void Seed(T context)
        {
            ISeedDatabase seeder = context as ISeedDatabase;
            if (seeder != null)
            {
                seeder.Seed();
            }
        }

        private static string ReplaceDataDirectory(string inputString)
        {
            string str = inputString.Trim();
            if (string.IsNullOrEmpty(inputString)
                || !inputString.StartsWith("|DataDirectory|", StringComparison.InvariantCultureIgnoreCase))
            {
                return str;
            }

            string data = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
            if (string.IsNullOrEmpty(data))
            {
                data = AppDomain.CurrentDomain.BaseDirectory;
            }

            if (string.IsNullOrEmpty(data))
            {
                data = string.Empty;
            }

            int length = "|DataDirectory|".Length;
            if ((inputString.Length > "|DataDirectory|".Length) && ('\\' == inputString["|DataDirectory|".Length]))
            {
                length++;
            }

            return Path.Combine(data, inputString.Substring(length));
        }

        #endregion
    }
}
