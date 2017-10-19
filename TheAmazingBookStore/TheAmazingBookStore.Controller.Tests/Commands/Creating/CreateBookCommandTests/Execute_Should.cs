using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using TheAmazingBookStore.Models;
using System.Collections.Generic;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Creating;
using System.Linq;

namespace TheAmazingBookStore.Controller.Tests.Commands.Creating.CreateBookCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateBook_WhenParametersAreCorrect()
        {
            var mockBook = new Mock<DbSet<Book>>();
            IList<string> parameters = new List<string>();

            var mockContext = new Mock<IBookStoreContext>();
            mockContext.Setup(m => m.Books).Returns(mockBook.Object);

            var book = new CreateBookCommand(mockContext.Object);
            book.Execute(parameters);

            mockBook.Verify(m => m.Add(It.IsAny<Book>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
