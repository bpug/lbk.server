// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201202141804343_AddEventThumbnailLink.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    #region using directives

    using System.Data.Entity.Migrations;

    #endregion

    public partial class AddEventThumbnailLink : DbMigration
    {
        #region - Public Methods -

        public override void Down()
        {
            this.DropColumn("Events", "ThumbnailLink");
        }

        public override void Up()
        {
            this.AddColumn("Events", "ThumbnailLink", c => c.String(maxLength: 255));
        }

        #endregion
    }
}
