namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureUserRated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureModelDtoes", "UserRated", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureModelDtoes", "UserRated");
        }
    }
}
