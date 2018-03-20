namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fluent_api_config_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Surveys", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Surveys", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(maxLength: 50));
            AlterColumn("dbo.Questions", "Text", c => c.String(maxLength: 300));
        }
    }
}
