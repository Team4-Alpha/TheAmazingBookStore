using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.GenreUpdateCommands
{
    public class UpdateGenreDescription : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateGenreDescription(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int genreId = int.Parse(parameters[0]);
            string newDescription = string.Empty;
            for (int i = 1; i < parameters.Count(); i++)
            {
                newDescription += parameters[i] + " ";
            }
            newDescription = newDescription.TrimEnd(' ');
            this.context.Genres.Find(genreId).Description = newDescription;
            this.context.SaveChanges();
            return $"The genre's description has been changed to \"{this.context.Genres.Find(genreId).Description}\".";
        }
    }
}
