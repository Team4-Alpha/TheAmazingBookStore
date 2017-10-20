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
    public class FindGenreCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public FindGenreCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public virtual string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            string name;
            string description;

            Genre genre = this.context.Genres.Find(id);

            name = genre.Name;
            description = genre.Description;

            var result = $@"Name: {name}
Description: {description}";
            return result;
        }
    }
}