using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Deleting
{
    public class DeleteSellerCommand:ICommand
    {
        private readonly IBookStoreContext context;

        public DeleteSellerCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            Seller seller = this.context.Sellers.Find(id);
            this.context.Sellers.Remove(seller);
            this.context.SaveChanges();
            return $"Seller with id {id} deleted";
        }
    }
}
