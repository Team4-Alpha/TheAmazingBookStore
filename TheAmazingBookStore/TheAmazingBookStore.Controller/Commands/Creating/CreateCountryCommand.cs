using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Creating
{
    public class CreateCountryCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public CreateCountryCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            Country country = new Country();
            this.context.Countries.Add(country);
            this.context.SaveChanges();

            return $"Country with Id {this.context.Countries.ToList().Last().Id} was created.";
        }
    }
}
