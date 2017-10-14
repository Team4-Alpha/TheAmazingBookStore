namespace TheAmazingBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CountriesAndSellerAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.SellerBooks",
                c => new
                    {
                        Seller_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seller_Id, t.Book_Id })
                .ForeignKey("dbo.Sellers", t => t.Seller_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Seller_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Countries", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.SellerBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.SellerBooks", "Seller_Id", "dbo.Sellers");
            DropIndex("dbo.SellerBooks", new[] { "Book_Id" });
            DropIndex("dbo.SellerBooks", new[] { "Seller_Id" });
            DropIndex("dbo.Countries", new[] { "Seller_Id" });
            DropTable("dbo.SellerBooks");
            DropTable("dbo.Countries");
            DropTable("dbo.Sellers");
        }
    }
}
