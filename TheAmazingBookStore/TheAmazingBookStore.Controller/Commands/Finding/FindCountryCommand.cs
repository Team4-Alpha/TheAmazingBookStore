using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.FindCommand
{
    public class FindCountryCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public FindCountryCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public virtual string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            string name;

            Country country = this.context.Countries.Find(id);

            name = country.Name;

            var result = $@"Country: {name}";
            return result;
        }
    }
}