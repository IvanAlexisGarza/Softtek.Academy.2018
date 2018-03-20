namespace DataAccesEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionOptionDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Options", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Question", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Question", "ModifyDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "ModifyDate");
            DropColumn("dbo.Question", "CreateDate");
            DropColumn("dbo.Options", "ModifyDate");
            DropColumn("dbo.Options", "CreateDate");
        }
    }
}
