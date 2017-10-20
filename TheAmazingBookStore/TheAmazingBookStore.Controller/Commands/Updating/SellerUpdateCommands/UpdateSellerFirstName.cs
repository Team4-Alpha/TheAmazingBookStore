using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.SellerUpdateCommands
{
    public class UpdateSellerFirstName : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateSellerFirstName(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int sellerId = int.Parse(parameters[0]);
            string firstName = parameters[1];
            this.context.Sellers.Find(sellerId).FirstName = firstName;
            this.context.SaveChanges();

            return $"Seller's First Name has been changed to \"{this.context.Sellers.Find(sellerId).FirstName}\".";
        }
    }
}
