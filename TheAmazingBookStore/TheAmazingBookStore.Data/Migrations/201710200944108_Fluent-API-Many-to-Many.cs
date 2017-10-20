namespace TheAmazingBookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPIManytoMany : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookAuthors", newName: "BookAuthor");
            RenameTable(name: "dbo.SellerBooks", newName: "BookSeller");
            RenameColumn(table: "dbo.BookAuthor", name: "Book_Id", newName: "BookRefId");
            RenameColumn(table: "dbo.BookAuthor", name: "Author_Id", newName: "AuthorRefId");
            RenameColumn(table: "dbo.BookSeller", name: "Seller_Id", newName: "SellerRefId");
            RenameColumn(table: "dbo.BookSeller", name: "Book_Id", newName: "BookRefId");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_Book_Id", newName: "IX_BookRefId");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_Author_Id", newName: "IX_AuthorRefId");
            RenameIndex(table: "dbo.BookSeller", name: "IX_Book_Id", newName: "IX_BookRefId");
            RenameIndex(table: "dbo.BookSeller", name: "IX_Seller_Id", newName: "IX_SellerRefId");
            DropPrimaryKey("dbo.BookSeller");
            AddPrimaryKey("dbo.BookSeller", new[] { "BookRefId", "SellerRefId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookSeller");
            AddPrimaryKey("dbo.BookSeller", new[] { "Seller_Id", "Book_Id" });
            RenameIndex(table: "dbo.BookSeller", name: "IX_SellerRefId", newName: "IX_Seller_Id");
            RenameIndex(table: "dbo.BookSeller", name: "IX_BookRefId", newName: "IX_Book_Id");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_AuthorRefId", newName: "IX_Author_Id");
            RenameIndex(table: "dbo.BookAuthor", name: "IX_BookRefId", newName: "IX_Book_Id");
            RenameColumn(table: "dbo.BookSeller", name: "BookRefId", newName: "Book_Id");
            RenameColumn(table: "dbo.BookSeller", name: "SellerRefId", newName: "Seller_Id");
            RenameColumn(table: "dbo.BookAuthor", name: "AuthorRefId", newName: "Author_Id");
            RenameColumn(table: "dbo.BookAuthor", name: "BookRefId", newName: "Book_Id");
            RenameTable(name: "dbo.BookSeller", newName: "SellerBooks");
            RenameTable(name: "dbo.BookAuthor", newName: "BookAuthors");
        }
    }
}
