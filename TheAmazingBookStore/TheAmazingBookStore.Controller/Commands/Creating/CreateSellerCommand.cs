using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Creating
{
    class CreateSellerCommand : ICommand
    {
        private readonly IBookStoreContext context;
        public CreateSellerCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            Seller seller = new Seller();
            this.context.Sellers.Add(seller);
            this.context.SaveChanges();

            return $"Seller with Id {this.context.Sellers.ToList().Last().Id} was created.";
        }
    }
}
