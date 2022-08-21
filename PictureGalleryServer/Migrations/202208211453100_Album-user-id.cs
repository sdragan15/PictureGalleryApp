namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Albumuserid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlbumModelDtoes", "User_Id", c => c.Int());
            CreateIndex("dbo.AlbumModelDtoes", "User_Id");
            AddForeignKey("dbo.AlbumModelDtoes", "User_Id", "dbo.UserModelDtoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumModelDtoes", "User_Id", "dbo.UserModelDtoes");
            DropIndex("dbo.AlbumModelDtoes", new[] { "User_Id" });
            DropColumn("dbo.AlbumModelDtoes", "User_Id");
        }
    }
}
