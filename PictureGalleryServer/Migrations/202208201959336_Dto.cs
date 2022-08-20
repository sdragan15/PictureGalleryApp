namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dto : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RegisterModels", newName: "RegisterModelDtoes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RegisterModelDtoes", newName: "RegisterModels");
        }
    }
}
