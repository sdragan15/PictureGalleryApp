namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imagedata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureModelDtoes", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureModelDtoes", "ImageData");
        }
    }
}
