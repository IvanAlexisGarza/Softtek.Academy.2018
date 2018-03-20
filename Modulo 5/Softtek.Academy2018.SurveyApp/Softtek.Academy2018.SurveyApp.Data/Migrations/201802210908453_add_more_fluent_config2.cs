namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_more_fluent_config2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "Text", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "Text", c => c.String(maxLength: 500));
        }
    }
}
