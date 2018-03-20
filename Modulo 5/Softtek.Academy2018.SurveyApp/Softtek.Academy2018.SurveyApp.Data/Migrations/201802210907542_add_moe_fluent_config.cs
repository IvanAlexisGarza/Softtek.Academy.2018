namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_moe_fluent_config : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "Text", c => c.String(maxLength: 500));
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Options", "Text", c => c.String());
        }
    }
}
