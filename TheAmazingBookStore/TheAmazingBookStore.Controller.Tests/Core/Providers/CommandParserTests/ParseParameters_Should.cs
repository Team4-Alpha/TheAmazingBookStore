using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAmazingBookStore.Controller.Core.Factories;
using TheAmazingBookStore.Controller.Core.Providers;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Tests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ListWithCorrectParameters_WhenFullCommandContainsParameters()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            string fullCommand = "updatecountryname 2 Bulgaria";
           
            List<string> expectedResult = new List<string>()
            {
               "The country's name has been changed to \"Bulgaria\"."
            };
            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseParameters(fullCommand).ToList();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, result);
        }
    }
}
