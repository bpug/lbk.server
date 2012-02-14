// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateIfNotExistsAndMigrateSqlInitializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Initializers
{
    #region using directives

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Transactions;

    using Lbk.MobileApp.Data.SqlCe.Migrations;

    #endregion

    internal class CreateIfNotExistsAndMigrateSqlInitializer<TContext> : SqlCeInitializer<TContext>
        where TContext : DbContext
    {
        #region - Public Methods -

        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var replacedContext = ReplaceSqlCeConnection(context);

            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                databaseExists = replacedContext.Database.Exists();
            }

            if (databaseExists)
            {
                if (!context.Database.CompatibleWithModel(throwIfNoMetadata: false))
                {
                    var migration = new DbMigrator(new Configuration());
                    migration.Update();
                }
            }
            else
            {
                ////context.Database.Create();
                var migration = new DbMigrator(new Configuration());
                migration.Update();
                this.Seed(context);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
