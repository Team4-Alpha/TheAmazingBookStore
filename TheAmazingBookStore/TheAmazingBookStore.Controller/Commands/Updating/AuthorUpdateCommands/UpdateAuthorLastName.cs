using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands
{
    public class UpdateAuthorLastName:ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateAuthorLastName(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int authorID = int.Parse(parameters[0]);
            string lastName = parameters[1];
            this.context.Authors.Find(authorID).LastName = lastName;
            this.context.SaveChanges();
            return $"Authors Last Name has been changed to \"{this.context.Authors.Find(authorID).LastName}\".";
        }
    }
}
