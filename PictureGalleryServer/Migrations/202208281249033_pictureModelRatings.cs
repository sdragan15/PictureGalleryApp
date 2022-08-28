namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pictureModelRatings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PictureModelDtoes", "NumberOfRatings", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PictureModelDtoes", "NumberOfRatings");
        }
    }
}
