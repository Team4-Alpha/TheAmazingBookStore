using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;
using TheAmazingBookStore.Controller.Commands.Deleting;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Tests.Commands.Deleting.DeleteBookCommandTests
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
            var command = new DeleteBookCommand(mockContext.Object);

            // Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new DeleteBookCommand(null));
        }
    }
}
