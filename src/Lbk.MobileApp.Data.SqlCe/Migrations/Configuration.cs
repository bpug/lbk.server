// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    #region using directives

    using System.Data.Entity.Migrations;

    #endregion

    internal sealed class Configuration : DbMigrationsConfiguration<MobileAppDbContext>
    {
        #region - Constructors and Destructors -

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        #endregion

        #region - Methods -

        protected override void Seed(MobileAppDbContext context)
        {
            // This method will be called after migrating to the latest version.

            // You can use the DbSet<T>.AddOrUpdate() helper extension method 
            // to avoid creating duplicate seed data. E.g.
            // context.People.AddOrUpdate(
            // p => p.FullName,
            // new Person { FullName = "Andrew Peters" },
            // new Person { FullName = "Brice Lambson" },
            // new Person { FullName = "Rowan Miller" }
            // );
        }

        #endregion
    }
}
