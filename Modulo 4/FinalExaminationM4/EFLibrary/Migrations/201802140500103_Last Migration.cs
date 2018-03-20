namespace EFLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Items_ItemId", "dbo.ItemInfo");
            DropIndex("dbo.Tags", new[] { "Items_ItemId" });
            DropColumn("dbo.Tags", "Items_ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Items_ItemId", c => c.Int());
            CreateIndex("dbo.Tags", "Items_ItemId");
            AddForeignKey("dbo.Tags", "Items_ItemId", "dbo.ItemInfo", "ItemId");
        }
    }
}
