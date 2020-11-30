using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestServiceChat
    {
        IrisLib.ServiceChat expectedServiceChat = new IrisLib.ServiceChat();

        private void initServiceChat()
        {
            expectedServiceChat.currentlyConnectedUsers.Clear();
            IrisLib.User user1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            IrisLib.User user2 = new IrisLib.User(121, "Tom", "Rifddle", "Marvolo", 53, "LordVolDeMort", "death");
            expectedServiceChat.currentlyConnectedUsers.Add(user1);
            expectedServiceChat.currentlyConnectedUsers.Add(user2);
        }

        [TestMethod]
        public void TestDisconnectExistingUser()
        {
            //Arrange
            initServiceChat();
            IrisLib.User user1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");

            //Act
            expectedServiceChat.Disconnect(user1);
            bool exp1 = expectedServiceChat.currentlyConnectedUsers.Contains(user1);
            
            //Assert
            Assert.IsFalse(exp1);
        }

        [TestMethod]
        public void TestDisconnectNonexistingUser()
        {
            //Arrange
            initServiceChat();
            IrisLib.User user3 = new IrisLib.User(121, "Harry", "Potter", "ChildLived", 11, "HateLordVolDeMort", "Jinny");

            //Act
            bool exp2 = true;
            try
            {
                expectedServiceChat.Disconnect(user3);
            }
            catch
            {
                exp2 = false;
            }

            //Assert
            Assert.IsTrue(exp2);
        }

        [TestMethod]
        public void TestDisconnectNull()
        {
            //Arrange
            initServiceChat();
            IrisLib.ServiceChat expectedServiceChat = new IrisLib.ServiceChat();

            //Act
            bool exp3 = true;
            try
            {
                expectedServiceChat.Disconnect(null);
            }
            catch
            {
                exp3 = false;
            }

            //Assert
            Assert.IsTrue(exp3);
        }
    }
}
