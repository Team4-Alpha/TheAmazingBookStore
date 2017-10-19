using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.GenreUpdateCommands
{
    public class UpdateGenreName : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateGenreName(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int genreId = int.Parse(parameters[0]);
            string newName = string.Empty;
            for (int i = 1; i < parameters.Count(); i++)
            {
                newName += parameters[i] + " ";
            }
            newName = newName.TrimEnd(' ');
            this.context.Genres.Where(g => g.Id == genreId).ToList()[0].Name = newName;
            this.context.SaveChanges();
            return $"The genre's name has been changed to \"{this.context.Genres.Where(g => g.Id == genreId).ToList()[0].Name}\".";
        }
    }
}
