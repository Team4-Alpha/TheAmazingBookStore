namespace TheAmazingBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountryIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Sellers", "CountryId", "dbo.Countries");
            DropIndex("dbo.Authors", new[] { "CountryId" });
            DropIndex("dbo.Sellers", new[] { "CountryId" });
            AlterColumn("dbo.Authors", "CountryId", c => c.Int());
            AlterColumn("dbo.Sellers", "CountryId", c => c.Int());
            CreateIndex("dbo.Authors", "CountryId");
            CreateIndex("dbo.Sellers", "CountryId");
            AddForeignKey("dbo.Authors", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.Sellers", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sellers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Authors", "CountryId", "dbo.Countries");
            DropIndex("dbo.Sellers", new[] { "CountryId" });
            DropIndex("dbo.Authors", new[] { "CountryId" });
            AlterColumn("dbo.Sellers", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "CountryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sellers", "CountryId");
            CreateIndex("dbo.Authors", "CountryId");
            AddForeignKey("dbo.Sellers", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Authors", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
