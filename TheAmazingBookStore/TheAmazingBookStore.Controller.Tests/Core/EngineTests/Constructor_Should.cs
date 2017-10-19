using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TheAmazingBookStore.Controller.Core.Contracts;
using TheAmazingBookStore.Controller.Core;

namespace TheAmazingBookStore.Controller.Tests.Core.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var processorMock = new Mock<IProcessor>();

            // Act
            var engine = new Engine(readerMock.Object, writerMock.Object, parserMock.Object, processorMock.Object);

            // Assert
            Assert.IsNotNull(engine);
        }

        [TestMethod]
        public void ThrowException_WhenReaderArgumentIsNull()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();
            var parserMock = new Mock<IParser>();
            var processorMock = new Mock<IProcessor>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new Engine(null, writerMock.Object, parserMock.Object, processorMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenWriterArgumentIsNull()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var parserMock = new Mock<IParser>();
            var processorMock = new Mock<IProcessor>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new Engine(readerMock.Object, null, parserMock.Object, processorMock.Object));
        }
    }
}
