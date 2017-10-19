using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Commands.Contracts;
using TheAmazingBookStore.Controller.Core;

namespace TheAmazingBookStore.Controller.Tests.Core.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallWriteMethodWithExceptionMessage_WhenExceptionIsThrown()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var processorMock = new Mock<IProcessor>();
            var commandMock = new Mock<ICommand>();
            string exceptionMessage = "test";

            readerMock.SetupSequence(m => m.ReadLine()).Returns("some command").Returns("Exit");

            parserMock.Setup(m => m.ParseCommand(It.IsAny<string>())).Returns(commandMock.Object);

            processorMock.Setup(m => m.ProcessCommand(It.IsAny<string>()))
                .Throws(new Exception(exceptionMessage));

            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, processorMock.Object);

            // Act
            engine.Start();

            // Assert
            writerMock.Verify(m => m.WriteLine(exceptionMessage), Times.Once());
        }
    }
}
