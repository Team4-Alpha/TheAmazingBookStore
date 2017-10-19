using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.Creating
{
    public class CreateBookCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public CreateBookCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            Book book = new Book();
            this.context.Books.Add(book);
            this.context.SaveChanges();

            return $"Book with Id {this.context.Books.ToList().Last().Id} was created.";
        }
    }
}
