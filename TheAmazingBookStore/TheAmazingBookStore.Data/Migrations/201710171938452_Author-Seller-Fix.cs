namespace TheAmazingBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorSellerFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Sellers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sellers", "LastName", c => c.Double(nullable: false));
            AlterColumn("dbo.Authors", "LastName", c => c.Double(nullable: false));
        }
    }
}
