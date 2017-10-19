using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands
{
    public class UpdateAuthorCountry : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateAuthorCountry(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int authorID = int.Parse(parameters[0]);
            string country = (parameters[1]);
            Country countryObject = this.context.Countries.First(c => c.Name == country);
            this.context.Authors.Find(authorID).Country = countryObject;
            this.context.SaveChanges();

            return $"Authors country has been changed to \"{this.context.Authors.Find(authorID).Country.Name}\".";
        }
    }
}
