using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WolfPack.ILoveBeer.Domain.Entities;
using WolfPack.ILoveBeer.Domain.ValueObjects;
using WolfPack.ILoveBeer.Infrastructure.Persistence.Contracts;
using WolfPack.ILoveBeer.Infrastructure.Persistence.Tests.Setup;

namespace WolfPack.ILoveBeer.Infrastructure.Persistence.Tests
{
    [TestClass]
    public class PersonDapperRepositoryTests
    {
        [TestMethod]
        public void GetAll_ReturnsSomePersons()
        {
            // Arrange
            var expected = new[]
            {
                new Person("John", "Doe", new DateTime(1989, 7, 2), Gender.Male),
                new Person("Marie", "Blabla", new DateTime(1987, 8, 4), Gender.Female)
            };
            var dbConnection = new DatabaseBuilder().WithPersonsTable(expected).Build();
            var dbConnectionFactory = new Mock<IDbConnectionFactory>();
            dbConnectionFactory.Setup(fact => fact.GetConnection())
                .Returns(dbConnection);

            var sut = new PersonDapperRepository(dbConnectionFactory.Object);

            // Act
            var actual = sut.GetAll().ToArray();

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Length, actual.Length);
        }
    }
}
