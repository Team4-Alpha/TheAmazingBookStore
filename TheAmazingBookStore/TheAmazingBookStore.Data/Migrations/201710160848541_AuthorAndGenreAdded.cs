namespace TheAmazingBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAndGenreAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Author_Id", c => c.Int());
            AddColumn("dbo.Countries", "Author_Id", c => c.Int());
            CreateIndex("dbo.Books", "Author_Id");
            CreateIndex("dbo.Countries", "Author_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
            AddForeignKey("dbo.Countries", "Author_Id", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Countries", new[] { "Author_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropColumn("dbo.Countries", "Author_Id");
            DropColumn("dbo.Books", "Author_Id");
            DropTable("dbo.Genres");
            DropTable("dbo.Authors");
        }
    }
}
