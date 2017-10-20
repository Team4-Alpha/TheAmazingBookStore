using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TheAmazingBookStore.Controller.Commands.Creating;
using TheAmazingBookStore.Data.Abstractions;
using TheAmazingBookStore.Models;

namespace TheAmazingBookStore.Controller.Tests.Commands.Creating.CreateBookCommandTests
{
    [TestClass]
    public class Execute_Should
    {

        //Can't handle this anymore
        [TestMethod]
        public void ReturnTheRightMessage_WhenTheParametersAreCorrect()
        {
            IQueryable<Book> books = new List<Book>()
            {
                new Book()
            }.AsQueryable();
            

            var book = new Book();

            var expected = $"Book with d";
            var setMock = new Mock<DbSet<Book>>();
            //Act

            //Assert
            Assert.AreEqual(expected, 1);

        }
    }
}
