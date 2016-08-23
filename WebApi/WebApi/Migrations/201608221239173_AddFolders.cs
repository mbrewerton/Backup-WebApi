namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFolders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApiKeyId = c.Guid(nullable: false),
                        FolderName = c.String(),
                        ApiKey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApiKeys", t => t.ApiKey_Id)
                .Index(t => t.ApiKey_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "ApiKey_Id", "dbo.ApiKeys");
            DropIndex("dbo.Folders", new[] { "ApiKey_Id" });
            DropTable("dbo.Folders");
        }
    }
}
