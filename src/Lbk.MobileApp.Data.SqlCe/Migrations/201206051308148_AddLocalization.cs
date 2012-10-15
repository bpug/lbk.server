namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddLocalization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Language",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Language(Code, Name, IsDefault) VALUES ('de-DE', 'Deutsch', 1)");
            Sql("INSERT INTO Language(Code, Name, IsDefault) VALUES ('en-GB', 'English', 0)");
            
            CreateTable(
                "LocalizableEntityTranslation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PrimaryKeyValue = c.Long(nullable: false),
                        FieldName = c.String(nullable: false, maxLength: 255),
                        Text = c.String(nullable: false),
                        LocalizableEntityId = c.Long(nullable: false),
                        LanguageId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LocalizableEntity", t => t.LocalizableEntityId, cascadeDelete: true)
                .ForeignKey("Language", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.LocalizableEntityId)
                .Index(t => t.LanguageId)
                .Index(t => new { t.LocalizableEntityId, t.PrimaryKeyValue, t.FieldName, t.LanguageId }, true);
            
            CreateTable(
                "LocalizableEntity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EntityName = c.String(nullable: false, maxLength: 255),
                        PrimaryKeyFieldName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Answer', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Category', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Event', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Food', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Menu', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Picture', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Question', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('QuestionCategory', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Serie', 'Id')");
            Sql("INSERT INTO LocalizableEntity(EntityName, PrimaryKeyFieldName) VALUES ('Video', 'Id')");
            
        }
        
        public override void Down()
        {
            DropIndex("LocalizableEntityTranslation", new[] { "LanguageId" });
            DropIndex("LocalizableEntityTranslation", new[] { "LocalizableEntityId" });
            DropForeignKey("LocalizableEntityTranslation", "LanguageId", "Language");
            DropForeignKey("LocalizableEntityTranslation", "LocalizableEntityId", "LocalizableEntity");
            DropTable("LocalizableEntity");
            DropTable("LocalizableEntityTranslation");
            DropTable("Language");
        }
    }
}
