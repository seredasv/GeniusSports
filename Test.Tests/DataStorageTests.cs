using NSubstitute;
using NUnit.Framework;
using Test.Core;

namespace Test.Tests
{
    public class DataStorageTests
    {
        private IDataStorage _storage;

        [Test]
        public void AddPerson_AddsOnePerson()
        {
            //act
            _storage.AddPerson("name", "surname");

            //assert
            Assert.IsTrue(_storage.Persons.Count == 6);
        }

        [Test]
        public void AddPerson_MethodTrigger()
        {
            //arrange
            var storage = Substitute.For<IDataStorage>();

            //act
            storage.AddPerson("name", "surname");

            //assert
            storage.Received().AddPerson("name", "surname");
        }

        [Test]
        public void AddPerson_MethodTrigger_WithWrongValues()
        {
            //arrange
            var storage = Substitute.For<IDataStorage>();

            //act
            storage.AddPerson("name", "surname");

            //assert
            storage.DidNotReceive().AddPerson(string.Empty, string.Empty);
        }

        [Test]
        public void GetPersons_ReturnFivePerson()
        {
            //act
            //assert
            Assert.IsTrue(_storage.Persons.Count == 5);
        }

        [SetUp]
        public void SetUp()
        {
            _storage = new DataStorage();
        }

        [TearDown]
        public void TearDown()
        {
            _storage = null;
        }
    }
}