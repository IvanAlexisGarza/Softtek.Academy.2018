namespace Academy2018.Final.Test.V2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Surveys", "StatusId", "dbo.Status");
            DropIndex("dbo.Surveys", new[] { "StatusId" });
            AddColumn("dbo.Surveys", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Surveys", "StatusId");
            DropTable("dbo.Status");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Surveys", "StatusId", c => c.Int(nullable: false));
            DropColumn("dbo.Surveys", "Status");
            CreateIndex("dbo.Surveys", "StatusId");
            AddForeignKey("dbo.Surveys", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
        }
    }
}
