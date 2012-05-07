namespace Lbk.MobileApp.Data.SqlCe.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEventThumbnailNameColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("Events", "ThumbnailName", c => c.String(maxLength: 255));
            Sql("Update Events Set ThumbnailName = RIGHT( ThumbnailLink, CHARINDEX( '/', REVERSE( ThumbnailLink)) - 1)");
        }
        
        public override void Down()
        {
            DropColumn("Events", "ThumbnailName");
        }
    }
}
