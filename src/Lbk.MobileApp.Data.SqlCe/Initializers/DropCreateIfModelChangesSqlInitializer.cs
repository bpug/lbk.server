// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropCreateIfModelChangesSqlInitializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Initializers
{
    #region using directives

    using System;
    using System.Data.Entity;
    using System.Transactions;

    #endregion

    internal class DropCreateIfModelChangesSqlInitializer<TContext> : SqlCeInitializer<TContext>
        where TContext : DbContext
    {
        #region - Public Methods -

        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                databaseExists = context.Database.Exists();
            }

            if (databaseExists)
            {
                if (context.Database.CompatibleWithModel(throwIfNoMetadata: true))
                {
                    return;
                }

                context.Database.Delete();
            }

            context.Database.Create();

            this.Seed(context);
            context.SaveChanges();
        }

        #endregion
    }
}
