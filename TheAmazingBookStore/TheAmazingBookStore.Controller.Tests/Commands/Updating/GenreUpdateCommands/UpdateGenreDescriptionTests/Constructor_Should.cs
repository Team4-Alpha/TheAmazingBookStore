using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using TheAmazingBookStore.Models;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Updating.GenreUpdateCommands;

namespace TheAmazingBookStore.Controller.Tests.Commands.Updating.GenreUpdateCommands.UpdateGenreDescriptionTests
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
            var command = new UpdateGenreDescription(mockContext.Object);

            // Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UpdateGenreDescription(null));
        }
    }
}
