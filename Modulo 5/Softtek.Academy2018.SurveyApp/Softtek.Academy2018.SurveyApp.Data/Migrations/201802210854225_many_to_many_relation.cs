namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class many_to_many_relation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "Option_Id", "dbo.Options");
            DropIndex("dbo.Questions", new[] { "Option_Id" });
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
            
            DropColumn("dbo.Questions", "Option_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "Option_Id", c => c.Int());
            DropForeignKey("dbo.QuestionOptions", "Option_Id", "dbo.Options");
            DropForeignKey("dbo.QuestionOptions", "Question_Id", "dbo.Questions");
            DropIndex("dbo.QuestionOptions", new[] { "Option_Id" });
            DropIndex("dbo.QuestionOptions", new[] { "Question_Id" });
            DropTable("dbo.QuestionOptions");
            CreateIndex("dbo.Questions", "Option_Id");
            AddForeignKey("dbo.Questions", "Option_Id", "dbo.Options", "Id");
        }
    }
}
