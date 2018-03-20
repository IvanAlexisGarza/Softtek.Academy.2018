namespace DataAccesEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.OptionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        QuestionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionType", t => t.QuestionTypeId, cascadeDelete: true)
                .Index(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.OptionId })
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.OptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "QuestionTypeId", "dbo.QuestionType");
            DropForeignKey("dbo.QuestionOptions", "OptionId", "dbo.Options");
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Question");
            DropIndex("dbo.QuestionOptions", new[] { "OptionId" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.Question", new[] { "QuestionTypeId" });
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.QuestionType");
            DropTable("dbo.Question");
            DropTable("dbo.Options");
        }
    }
}
