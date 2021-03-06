﻿using Bytes2you.Validation;
using System.Collections.Generic;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Updating.AuthorUpdateCommands
{
    public class UpdateAuthorFirstName : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateAuthorFirstName(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int authorID = int.Parse(parameters[0]);
            string firstName = parameters[1];
            this.context.Authors.Find(authorID).FirstName = firstName;
            this.context.SaveChanges();
            return $"Authors First Name has been changed to \"{this.context.Authors.Find(authorID).FirstName}\".";
        }
    }
}
