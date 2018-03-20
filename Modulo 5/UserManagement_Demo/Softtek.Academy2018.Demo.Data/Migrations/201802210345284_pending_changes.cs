namespace Softtek.Academy2018.Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pending_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "ProjectId" });
            AlterColumn("dbo.Users", "ProjectId", c => c.Int());
            CreateIndex("dbo.Users", "ProjectId");
            AddForeignKey("dbo.Users", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "ProjectId" });
            AlterColumn("dbo.Users", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "ProjectId");
            AddForeignKey("dbo.Users", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
