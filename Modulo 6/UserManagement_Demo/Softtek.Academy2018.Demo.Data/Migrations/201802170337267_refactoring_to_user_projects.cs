namespace Softtek.Academy2018.Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring_to_user_projects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProjects", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "User_Id" });
            DropIndex("dbo.UserProjects", new[] { "Project_Id" });
            AddColumn("dbo.Users", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "ProjectId");
            AddForeignKey("dbo.Users", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            DropTable("dbo.UserProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Project_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Project_Id });
            
            DropForeignKey("dbo.Users", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Users", new[] { "ProjectId" });
            DropColumn("dbo.Users", "ProjectId");
            CreateIndex("dbo.UserProjects", "Project_Id");
            CreateIndex("dbo.UserProjects", "User_Id");
            AddForeignKey("dbo.UserProjects", "Project_Id", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserProjects", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
