﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data.Abstractions;

namespace TheAmazingBookStore.Controller.Commands.Update.BookUpdateCommands
{
    public class UpdateBookPrice : ICommand
    {
        private readonly IBookStoreContext context;

        public UpdateBookPrice(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            int bookId = int.Parse(parameters[0]);
            decimal newPrice = decimal.Parse(parameters[1]);
            this.context.Books.Where(b => b.Id == bookId).ToList()[0].Price = newPrice;
            this.context.SaveChanges();
            return $"Book's title has been changed to \"{this.context.Books.Where(b => b.Id == bookId).ToList()[0].Price}\".";
        }
    }
}