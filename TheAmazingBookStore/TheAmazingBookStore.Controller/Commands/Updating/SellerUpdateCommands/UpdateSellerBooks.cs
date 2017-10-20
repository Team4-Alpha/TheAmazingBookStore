using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Updating.SellerUpdateCommands
{
   public class UpdateSellerBooks : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateSellerBooks(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }
        //TODO 
        public string Execute(IList<string> parameters)
        {
            int sellerId = int.Parse(parameters[0]);
            var bookString = (parameters[1]);
            
            var book = this.context.Books.First(b => b.Title == bookString);

            var seller = this.context.Authors.Find(sellerId);
            seller.Books.Add(book);

            this.context.SaveChanges();
            return $"{book.Title} has been added to {seller.FirstName} {seller.LastName}.";
        }
    }
}
