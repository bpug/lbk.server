// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropCreateAlwaysSqlCeInitializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Initializers
{
    #region using directives

    using System;
    using System.Data.Entity;

    #endregion

    internal class DropCreateAlwaysSqlCeInitializer<TContext> : SqlCeInitializer<TContext>
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

            if (replacedContext.Database.Exists())
            {
                replacedContext.Database.Delete();
            }

            context.Database.Create();
            this.Seed(context);
            context.SaveChanges();
        }

        #endregion
    }
}
