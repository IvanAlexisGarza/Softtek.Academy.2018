namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_context_add_option_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Questions", "Option_Id", c => c.Int());
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(nullable: false, maxLength: 400));
            CreateIndex("dbo.Questions", "Option_Id");
            AddForeignKey("dbo.Questions", "Option_Id", "dbo.Options", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Option_Id", "dbo.Options");
            DropIndex("dbo.Questions", new[] { "Option_Id" });
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Questions", "Option_Id");
            DropTable("dbo.Options");
        }
    }
}
