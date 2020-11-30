using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void TestEquals()
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

            //Act
            bool isEquals1 = expectedUser1.Equals(expectedUser2);
            bool isEquals2 = expectedUser1.Equals(expectedUser3);
            bool isEquals3 = expectedUser2.Equals(expectedUser3);

            //Assert
            Assert.IsTrue(isEquals1);
            Assert.IsFalse(isEquals2);
            Assert.IsFalse(isEquals3);
        }
    }
}
