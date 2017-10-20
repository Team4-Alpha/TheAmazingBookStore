using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Data;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Commands.FindCommand
{
    public class FindAuthorCommand : ICommand
    {
        private readonly IBookStoreContext context;

        public FindAuthorCommand(IBookStoreContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public virtual string Execute(IList<string> parameters)
        {
            int id = int.Parse(parameters[0]);
            string firstName;
            string lastName;
            string country;
            string books = "";

            Author author = this.context.Authors.Find(id);

            firstName = author.FirstName;
            lastName = author.LastName;
            country = author.Country.Name;

            foreach (var book in author.Books)
            {
                books += (book.Title + "\n");
            }

            var result = $@"First Name: {firstName}
Last Name: {lastName}
Country: {country}
Books: {books}";
            return result;
        }
    }
}