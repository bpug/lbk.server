namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureTitleColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("Pictures", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("Pictures", "FileName", c => c.String(maxLength: 255));
            AlterColumn("Pictures", "Link", c => c.String(maxLength: 255));

            Sql("UPDATE Pictures SET Title=FileName");
            Sql("UPDATE Pictures SET FileName=''");
        }
        
        public override void Down()
        {
            AlterColumn("Pictures", "Link", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("Pictures", "FileName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("Pictures", "Title");
        }
    }
}
