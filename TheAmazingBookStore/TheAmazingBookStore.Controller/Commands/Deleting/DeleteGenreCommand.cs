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
    class DeleteGenreCommand:ICommand
    {
        private readonly IBookStoreContext context;

        public DeleteGenreCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            Genre genre = this.context.Genres.Find(id);

            this.context.Genres.Remove(genre);
            this.context.SaveChanges();

            return $"Genre with id {id} deleted";
        }
    }
}
