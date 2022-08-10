namespace PictureGalleryServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropTable("dbo.RegisterModels");
        }
    }
}
