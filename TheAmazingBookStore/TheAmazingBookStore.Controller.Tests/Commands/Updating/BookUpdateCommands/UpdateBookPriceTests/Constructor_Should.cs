using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using TheAmazingBookStore.Models;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Updating.BookUpdateCommands;

namespace TheAmazingBookStore.Controller.Tests.Commands.Updating.BookUpdateCommands.UpdateBookPriceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var mockBook = new Mock<DbSet<Book>>();

            var mockContext = new Mock<IBookStoreContext>();
            mockContext.Setup(m => m.Books).Returns(mockBook.Object);

            // Act
            var command = new UpdateBookPrice(mockContext.Object);

            // Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UpdateBookPrice(null));
        }
    }
}
