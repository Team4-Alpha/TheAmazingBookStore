using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;
using TheAmazingBookStore.Controller.Commands.Updating.GenreUpdateCommands;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Tests.Commands.Updating.GenreUpdateCommands.UpdateGenreNameTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var mockGenre = new Mock<DbSet<Genre>>();

            var mockContext = new Mock<IBookStoreContext>();
            mockContext.Setup(m => m.Genres).Returns(mockGenre.Object);

            // Act
            var command = new UpdateGenreName(mockContext.Object);

            // Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UpdateGenreName(null));
        }
    }
}
