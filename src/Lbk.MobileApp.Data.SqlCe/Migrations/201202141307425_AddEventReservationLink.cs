// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201202141307425_AddEventReservationLink.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    #region using directives

    using System.Data.Entity.Migrations;

    #endregion

    public partial class AddEventReservationLink : DbMigration
    {
        #region - Public Methods -

        public override void Down()
        {
            this.DropColumn("Events", "ReservationLink");
        }

        public override void Up()
        {
            this.AddColumn("Events", "ReservationLink", c => c.String(maxLength: 255));
        }

        #endregion
    }
}
