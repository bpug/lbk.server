namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddLogAndLogType : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "Log",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Fingerprint = c.String(maxLength: 50),
            //            InsertTime = c.DateTime(nullable: false),
            //            LogType = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("LogType", t => t.LogType, cascadeDelete: true)
            //    .Index(t => t.LogType);
            
            //CreateTable(
            //    "LogType",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Description = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            //DropIndex("Log", new[] { "LogType" });
            //DropForeignKey("Log", "LogType", "LogType");
            //DropTable("LogType");
            //DropTable("Log");
        }
    }
}
