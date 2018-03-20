namespace EFLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lastlast : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Title", c => c.String());
        }
    }
}
