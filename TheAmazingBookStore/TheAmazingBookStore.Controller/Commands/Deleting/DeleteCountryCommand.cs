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
    class DeleteCountryCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public DeleteCountryCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            Country country = this.context.Countries.Find(id);

            this.context.Countries.Remove(country);
            this.context.SaveChanges();

            return $"Country with id {id} deleted";
        }
    }
}
