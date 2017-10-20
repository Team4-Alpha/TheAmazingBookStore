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
    public class UpdateSellerCountry : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateSellerCountry(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int sellerId = int.Parse(parameters[0]);
            string country = (parameters[1]);
            Country countryObject = this.context.Countries.First(c => c.Name == country);
            this.context.Sellers.Find(sellerId).Country = countryObject;
            this.context.SaveChanges();

            return $"Seller's country has been changed to \"{this.context.Sellers.Find(sellerId).Country.Name}\".";
        }
    }
}
