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

            //Act
            bool isEquals = expectedUser1.Equals(expectedUser2);

            //Assert
            Assert.AreEqual(isEquals, true);

        }
    }
}
