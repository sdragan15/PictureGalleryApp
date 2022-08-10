namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerRolesProerty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterModels", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterModels", "Role");
        }
    }
}
