namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_many_to_many_relation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.Questions", new[] { "Survey_Id" });
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
            
            DropColumn("dbo.Questions", "Survey_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Survey_Id", c => c.Int());
            DropForeignKey("dbo.SurveyQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.SurveyQuestions", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.SurveyQuestions", new[] { "Question_Id" });
            DropIndex("dbo.SurveyQuestions", new[] { "Survey_Id" });
            DropTable("dbo.SurveyQuestions");
            CreateIndex("dbo.Questions", "Survey_Id");
            AddForeignKey("dbo.Questions", "Survey_Id", "dbo.Surveys", "Id");
        }
    }
}
