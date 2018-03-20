namespace DataAccesEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateQuestionType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionType", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionType", "Date");
        }
    }
}
