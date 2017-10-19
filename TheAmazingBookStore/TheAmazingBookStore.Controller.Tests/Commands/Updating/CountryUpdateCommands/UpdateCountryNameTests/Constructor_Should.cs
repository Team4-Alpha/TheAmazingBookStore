using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using TheAmazingBookStore.Models;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Controller.Commands.Updating.CountryUpdateCommands;

namespace TheAmazingBookStore.Controller.Tests.Commands.Updating.CountryUpdateCommands.UpdateCountryNameTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var mockCountry = new Mock<DbSet<Country>>();

            var mockContext = new Mock<IBookStoreContext>();
            mockContext.Setup(m => m.Countries).Returns(mockCountry.Object);

            // Act
            var command = new UpdateCountryName(mockContext.Object);

            // Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UpdateCountryName(null));
        }
    }
}
