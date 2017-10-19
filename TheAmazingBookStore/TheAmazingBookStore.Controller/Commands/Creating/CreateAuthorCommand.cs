using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Creating
{
    public class CreateAuthorCommand : ICommand
    {
        private readonly IBookStoreContext context;
        
        public CreateAuthorCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            Author author = new Author();
            this.context.Authors.Add(author);
            this.context.SaveChanges();

            return $"Author with Id {this.context.Authors.ToList().Last().Id} was created.";
        }
    }
}
