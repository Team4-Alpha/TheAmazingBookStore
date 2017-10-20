namespace TheAmazingBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributesAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Authors", "LastName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Books", "Title", c => c.String(maxLength: 100));
            AlterColumn("dbo.Genres", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Sellers", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Sellers", "LastName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Countries", "Name", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Countries", "Name", c => c.String());
            AlterColumn("dbo.Sellers", "LastName", c => c.String());
            AlterColumn("dbo.Sellers", "FirstName", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Authors", "FirstName", c => c.String());
        }
    }
}
