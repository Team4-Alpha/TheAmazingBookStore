using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Update.CountryUpdateCommands
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
            string newName = parameters[1];
            this.context.Countries.First(c => c.Id == countryId).Name = newName;
            this.context.SaveChanges();
            return $"Country's name has been changed to \"{this.context.Countries.First(c => c.Id == countryId).Name}\".";
        }
    }
}
