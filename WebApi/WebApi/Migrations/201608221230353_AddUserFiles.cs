namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApiKeyId = c.Guid(nullable: false),
                        FileName = c.String(),
                        Folder = c.String(),
                        ApiKey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApiKeys", t => t.ApiKey_Id)
                .Index(t => t.ApiKey_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFiles", "ApiKey_Id", "dbo.ApiKeys");
            DropIndex("dbo.UserFiles", new[] { "ApiKey_Id" });
            DropTable("dbo.UserFiles");
        }
    }
}
