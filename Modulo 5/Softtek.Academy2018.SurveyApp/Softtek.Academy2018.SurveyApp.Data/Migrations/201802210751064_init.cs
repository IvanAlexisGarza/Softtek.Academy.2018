namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        QuestionTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModiedDate = c.DateTime(),
                        Survey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .Index(t => t.QuestionTypeId)
                .Index(t => t.Survey_Id);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IsArchived = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropIndex("dbo.Questions", new[] { "Survey_Id" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropTable("dbo.Surveys");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
        }
    }
}
