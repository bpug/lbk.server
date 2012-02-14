// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201202141817367_AddVideoTable.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    #region using directives

    using System.Data.Entity.Migrations;

    #endregion

    public partial class AddVideoTable : DbMigration
    {
        #region - Public Methods -

        public override void Down()
        {
            this.DropTable("Videos");
        }

        public override void Up()
        {
            this.CreateTable(
                "Videos", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        Description = c.String(maxLength: 255), 
                        FileName = c.String(nullable: false, maxLength: 255), 
                        Link = c.String(nullable: false, maxLength: 255), 
                        SortOrder = c.Int(nullable: false), 
                        ThumbnailLink = c.String(maxLength: 255), 
                    }).PrimaryKey(t => t.Id);
        }

        #endregion
    }
}
