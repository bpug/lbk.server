// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateIfNotExistsSqlCeInitializer.cs" company="ip-connect GmbH">
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

    internal class CreateIfNotExistsSqlCeInitializer<TContext> : SqlCeInitializer<TContext>
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
                    throw new InvalidOperationException(
                        string.Format(
                            "The model backing the '{0}' context has changed since the database was created. Either manually delete/update the database, or call Database.SetInitializer with an IDatabaseInitializer instance. For example, the DropCreateDatabaseIfModelChanges strategy will automatically delete and recreate the database, and optionally seed it with new data.", 
                            context.GetType().Name));
                }
            }
            else
            {
                context.Database.Create();
                this.Seed(context);
                context.SaveChanges();
            }
        }

        #endregion
    }
}
