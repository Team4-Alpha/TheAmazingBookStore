using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;

namespace TheAmazingBookStore.Controller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        [DataRow("createbook")]
        [DataRow("updatebook 5")]
        [DataRow("deleteauthor dsdssd")]
        [DataRow("updatebooktitle dsdssd")]
        public void ReturnCommand_WhenParameterIsCorrect(string fullCommand, string commandName)
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            factoryMock.Setup(m => m.CreateCommand(commandName)).Returns(commandMock.Object);

            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseCommand(fullCommand);

            // Assert
            Assert.AreEqual(commandMock.Object, result);
        }
    }
}
