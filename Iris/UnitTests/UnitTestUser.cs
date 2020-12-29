using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void TestEqualsSameUsers()
        {
            //Arrange
            IrisLib.User expectedUser1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            IrisLib.User expectedUser2 = new IrisLib.User()
            {
                ID = 111,
                Name = "Ivan",
                Surname = "Vinogradov",
                Nickname = "FunnySurname",
                Age = 0,
                Login = "Vina",
                Password = "qwerty123"
            };
            //Act
            bool isEquals1 = expectedUser1.Equals(expectedUser2);

            //Assert
            Assert.IsTrue(isEquals1);
        }

        [TestMethod]
        public void TestEqualsDifferentUsers()
        {
            //Arrange
            IrisLib.User expectedUser1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            IrisLib.User expectedUser2 = new IrisLib.User()
            {
                ID = 111,
                Name = "Ivan",
                Surname = "Vinogradov",
                Nickname = "FunnySurname",
                Age = 0,
                Login = "Vina",
                Password = "qwerty123"
            };
            IrisLib.User expectedUser3 = new IrisLib.User(121, "Tom", "Rifddle", "Marvolo", 53, "LordVolDeMort", "death");
            IrisLib.User expectedUser4 = new IrisLib.User() { ID = 5, Name = "Someone" };

            //Act
            bool isEquals2 = expectedUser1.Equals(expectedUser3);
            bool isEquals3 = expectedUser2.Equals(expectedUser3);
            bool isEquals4 = expectedUser2.Equals(expectedUser4);

            //Assert
            Assert.IsFalse(isEquals2);
            Assert.IsFalse(isEquals3);
            Assert.IsFalse(isEquals4);
        }

        [TestMethod]
        public void TestEqualsWithNull()
        {
            //Arrange
            IrisLib.User expectedUser1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            IrisLib.User expectedUser5 = null;

            //Act
            bool isEquals5 = expectedUser1.Equals(expectedUser5);

            //Assert
            Assert.IsFalse(isEquals5);
        }
    }
}
