namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbEntity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "UserModelDtoes");
            AddColumn("dbo.RegisterModelDtoes", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserModelDtoes", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserModelDtoes", "IsDeleted");
            DropColumn("dbo.RegisterModelDtoes", "IsDeleted");
            RenameTable(name: "dbo.UserModelDtoes", newName: "Users");
        }
    }
}
