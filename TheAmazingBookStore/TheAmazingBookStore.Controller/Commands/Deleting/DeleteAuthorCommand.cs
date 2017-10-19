using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Deleting
{
    public class DeleteAuthorCommand:ICommand
    {
        private readonly IBookStoreContext context;

        public DeleteAuthorCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }
        //delete author with first name
        public string Execute(IList<string> parameters)
        {
            string fname = parameters[0];
            Author author = this.context.Authors.First(b => b.FirstName == fname);
            this.context.Authors.Remove(author);
            this.context.SaveChanges();
            return "Author deleted";
        }
    }
}
