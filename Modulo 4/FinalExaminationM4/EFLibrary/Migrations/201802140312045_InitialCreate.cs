namespace EFLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemInfo",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Archived = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        ModDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Items_ItemId = c.Int(),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.ItemInfo", t => t.Items_ItemId)
                .Index(t => t.Items_ItemId);
            
            CreateTable(
                "dbo.ItemTags",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.ItemId })
                .ForeignKey("dbo.ItemInfo", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemTags", "ItemId", "dbo.Tags");
            DropForeignKey("dbo.ItemTags", "TagId", "dbo.ItemInfo");
            DropForeignKey("dbo.Tags", "Items_ItemId", "dbo.ItemInfo");
            DropIndex("dbo.ItemTags", new[] { "ItemId" });
            DropIndex("dbo.ItemTags", new[] { "TagId" });
            DropIndex("dbo.Tags", new[] { "Items_ItemId" });
            DropTable("dbo.ItemTags");
            DropTable("dbo.Tags");
            DropTable("dbo.ItemInfo");
        }
    }
}
