namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_fluent_api_config_3_Add_Questions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Modified", c => c.DateTime());
            AddColumn("dbo.QuestionTypes", "Modified", c => c.DateTime());
            AddColumn("dbo.Surveys", "Modified", c => c.DateTime());
            DropColumn("dbo.Questions", "ModiedDate");
            DropColumn("dbo.QuestionTypes", "ModiedDate");
            DropColumn("dbo.Surveys", "ModiedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "ModiedDate", c => c.DateTime());
            AddColumn("dbo.QuestionTypes", "ModiedDate", c => c.DateTime());
            AddColumn("dbo.Questions", "ModiedDate", c => c.DateTime());
            DropColumn("dbo.Surveys", "Modified");
            DropColumn("dbo.QuestionTypes", "Modified");
            DropColumn("dbo.Questions", "Modified");
        }
    }
}
