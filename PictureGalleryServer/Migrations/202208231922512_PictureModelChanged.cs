namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureModelDtoes", "AlbumId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureModelDtoes", "AlbumId");
        }
    }
}
