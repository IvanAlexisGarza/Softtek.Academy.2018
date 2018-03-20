namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_property_add_survey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.QuestionTypes", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Surveys", "ModifiedDate", c => c.DateTime());
            DropColumn("dbo.Questions", "Modified");
            DropColumn("dbo.QuestionTypes", "Modified");
            DropColumn("dbo.Surveys", "Modified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Surveys", "Modified", c => c.DateTime());
            AddColumn("dbo.QuestionTypes", "Modified", c => c.DateTime());
            AddColumn("dbo.Questions", "Modified", c => c.DateTime());
            DropColumn("dbo.Surveys", "ModifiedDate");
            DropColumn("dbo.QuestionTypes", "ModifiedDate");
            DropColumn("dbo.Questions", "ModifiedDate");
        }
    }
}
