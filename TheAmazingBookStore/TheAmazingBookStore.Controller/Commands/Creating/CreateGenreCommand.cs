using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Creating
{
    public class CreateGenreCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public CreateGenreCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            Genre genre = new Genre();
            this.context.Genres.Add(genre);
            this.context.SaveChanges();

            return $"Genre with Id {this.context.Genres.ToList().Last().Id} was created.";
        }
    }
}
