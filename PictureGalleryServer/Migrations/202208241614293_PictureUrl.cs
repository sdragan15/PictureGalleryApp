namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureModelDtoes", "ImageUrl", c => c.String());
            DropColumn("dbo.PictureModelDtoes", "ImageData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PictureModelDtoes", "ImageData", c => c.Binary());
            DropColumn("dbo.PictureModelDtoes", "ImageUrl");
        }
    }
}
