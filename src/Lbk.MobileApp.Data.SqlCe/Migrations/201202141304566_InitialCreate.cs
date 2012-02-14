// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201202141304566_InitialCreate.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    #region using directives

    using System.Data.Entity.Migrations;

    #endregion

    public partial class InitialCreate : DbMigration
    {
        #region - Public Methods -

        public override void Down()
        {
            this.DropIndex("Foods", new[] { "CategoryId" });
            this.DropIndex("Foods", new[] { "MenuId" });
            this.DropIndex("Questions", new[] { "SerieId" });
            this.DropIndex("Answers", new[] { "QuestionId" });
            this.DropForeignKey("Foods", "CategoryId", "Categories");
            this.DropForeignKey("Foods", "MenuId", "Menus");
            this.DropForeignKey("Questions", "SerieId", "Series");
            this.DropForeignKey("Answers", "QuestionId", "Questions");
            this.DropTable("Pictures");
            this.DropTable("Events");
            this.DropTable("Menus");
            this.DropTable("Foods");
            this.DropTable("Categories");
            this.DropTable("Series");
            this.DropTable("Questions");
            this.DropTable("Answers");
        }

        public override void Up()
        {
            this.CreateTable(
                "Answers", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        Description = c.String(maxLength: 255), 
                        Explanation = c.String(maxLength: 255), 
                        IsRight = c.Boolean(nullable: false), 
                        QuestionId = c.Long(nullable: false), 
                    }).PrimaryKey(t => t.Id).ForeignKey("Questions", t => t.QuestionId, cascadeDelete: true).Index(
                        t => t.QuestionId);

            this.CreateTable(
                "Questions", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        Description = c.String(maxLength: 255), 
                        Number = c.Int(nullable: false), 
                        Points = c.Int(nullable: false), 
                        SerieId = c.Long(nullable: false), 
                    }).PrimaryKey(t => t.Id).ForeignKey("Series", t => t.SerieId, cascadeDelete: true).Index(
                        t => t.SerieId);

            this.CreateTable(
                "Series", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        ActivatedAt = c.DateTime(nullable: false), 
                        Description = c.String(maxLength: 255), 
                        ExpiresAt = c.DateTime(nullable: false), 
                        IsActivated = c.Boolean(nullable: false), 
                    }).PrimaryKey(t => t.Id);

            this.CreateTable(
                "Categories", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        Description = c.String(maxLength: 255), 
                        Title = c.String(maxLength: 255), 
                    }).PrimaryKey(t => t.Id);

            this.CreateTable(
                "Foods", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        CategoryId = c.Long(nullable: false), 
                        Description = c.String(maxLength: 255), 
                        MenuId = c.Long(nullable: false), 
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2), 
                        SortOrder = c.Int(nullable: false), 
                        Title = c.String(maxLength: 255), 
                    }).PrimaryKey(t => t.Id).ForeignKey("Menus", t => t.MenuId, cascadeDelete: true).ForeignKey(
                        "Categories", t => t.CategoryId, cascadeDelete: true).Index(t => t.MenuId).Index(
                            t => t.CategoryId);

            this.CreateTable(
                "Menus", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        Date = c.DateTime(nullable: false), 
                        Description = c.String(maxLength: 255), 
                    }).PrimaryKey(t => t.Id);

            this.CreateTable(
                "Events", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        ActivatedAt = c.DateTime(nullable: false), 
                        Date = c.String(maxLength: 255), 
                        DateOrder = c.DateTime(nullable: false), 
                        Description = c.String(maxLength: 255), 
                        ExpiresAt = c.DateTime(nullable: false), 
                        IsActivated = c.Boolean(nullable: false), 
                        Title = c.String(maxLength: 255), 
                    }).PrimaryKey(t => t.Id);

            this.CreateTable(
                "Pictures", 
                c =>
                new
                    {
                        Id = c.Long(nullable: false, identity: true), 
                        Description = c.String(maxLength: 255), 
                        FileName = c.String(nullable: false, maxLength: 255), 
                        Link = c.String(nullable: false, maxLength: 255), 
                        SortOrder = c.Int(nullable: false), 
                    }).PrimaryKey(t => t.Id);
        }

        #endregion
    }
}
