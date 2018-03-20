namespace Academy2018.Final.Test.V2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        OpenText = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId)
                .Index(t => t.QuestionId)
                .Index(t => t.OptionId);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        ScoreValue = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        QuestionTypeId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, cascadeDelete: true)
                .Index(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
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
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Option_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Option_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.Option_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.Option_Id);
            
            CreateTable(
                "dbo.SurveyQuestions",
                c => new
                    {
                        Survey_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Survey_Id, t.Question_Id })
                .ForeignKey("dbo.Surveys", t => t.Survey_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Survey_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Answers", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Surveys", "StatusId", "dbo.Status");
            DropForeignKey("dbo.SurveyQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SurveyQuestions", "Survey_Id", "dbo.Surveys");
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropForeignKey("dbo.QuestionOptions", "Option_Id", "dbo.Options");
            DropForeignKey("dbo.QuestionOptions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.SurveyQuestions", new[] { "Question_Id" });
            DropIndex("dbo.SurveyQuestions", new[] { "Survey_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "Option_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "Question_Id" });
            DropIndex("dbo.Surveys", new[] { "StatusId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropIndex("dbo.Answers", new[] { "OptionId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "SurveyId" });
            DropTable("dbo.SurveyQuestions");
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.Status");
            DropTable("dbo.Surveys");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
            DropTable("dbo.Answers");
        }
    }
}
