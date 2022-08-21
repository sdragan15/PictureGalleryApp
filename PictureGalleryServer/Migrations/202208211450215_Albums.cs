namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Albums : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumModelDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PictureModelDtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        Tags = c.String(),
                        Rating = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        AlbumModelDto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlbumModelDtoes", t => t.AlbumModelDto_Id)
                .Index(t => t.AlbumModelDto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PictureModelDtoes", "AlbumModelDto_Id", "dbo.AlbumModelDtoes");
            DropIndex("dbo.PictureModelDtoes", new[] { "AlbumModelDto_Id" });
            DropTable("dbo.PictureModelDtoes");
            DropTable("dbo.AlbumModelDtoes");
        }
    }
}
