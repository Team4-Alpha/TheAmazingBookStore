using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;

namespace TheAmazingBookStore.Controller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            // Act
            var parser = new CommandParser(factoryMock.Object);

            // Assert
            Assert.IsNotNull(parser);
        }

        [TestMethod]
        public void ThrowException_WhenFactoryIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }
    }
}
