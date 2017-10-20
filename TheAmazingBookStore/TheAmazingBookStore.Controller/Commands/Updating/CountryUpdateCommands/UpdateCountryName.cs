using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.CountryUpdateCommands
{
    public class UpdateCountryName : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateCountryName(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int countryId = int.Parse(parameters[0]);
            string newName = string.Empty;
            for (int i = 1; i < parameters.Count(); i++)
            {
                newName += parameters[i] + " ";
            }
            newName = newName.TrimEnd(' ');
            this.context.Countries.Find(countryId).Name = newName;
            this.context.SaveChanges();
            return $"The country's name has been changed to \"{this.context.Countries.Find(countryId).Name}\".";
        }
    }
}