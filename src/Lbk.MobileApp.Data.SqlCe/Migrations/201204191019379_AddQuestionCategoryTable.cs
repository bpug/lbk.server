namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "QuestionCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.Id).Index(t => t.Title, true);

            Sql("INSERT INTO QuestionCategories(Title) VALUES ('NONE')");
            Sql("INSERT INTO QuestionCategories(Title) VALUES ('BAY')");
            Sql("INSERT INTO QuestionCategories(Title) VALUES ('BIE')");
            Sql("INSERT INTO QuestionCategories(Title) VALUES ('FOD')");
            Sql("INSERT INTO QuestionCategories(Title) VALUES ('LBK')");
            Sql("INSERT INTO QuestionCategories(Title) VALUES ('MUC')");
            Sql("INSERT INTO QuestionCategories(Title) VALUES ('SCH')");

            AddColumn("Questions", "CategoryId", c => c.Long(nullable: false, defaultValue: 1));
            AddForeignKey("Questions", "CategoryId", "QuestionCategories", "Id", cascadeDelete: true);
            CreateIndex("Questions", "CategoryId");
        }
        
        public override void Down()
        {
            DropIndex("Questions", new[] { "CategoryId" });
            DropForeignKey("Questions", "CategoryId", "QuestionCategories");
            DropColumn("Questions", "CategoryId");
            DropTable("QuestionCategories");
        }
    }
}
