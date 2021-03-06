﻿using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.BookUpdateCommands
{
    public class UpdateBookDescription : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateBookDescription(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int bookId = int.Parse(parameters[0]);
            string newDescription = string.Empty;
            for (int i = 1; i < parameters.Count(); i++)
            {
                newDescription += parameters[i] + " ";
            }
            newDescription = newDescription.TrimEnd(' ');
            this.context.Books.Find(bookId).Description = newDescription;
            this.context.SaveChanges();
            return $"The book's description has been changed to \"{this.context.Books.Find(bookId).Description}\".";
        }
    }
}
