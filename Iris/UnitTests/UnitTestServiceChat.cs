using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTestServiceChat
    {
        [TestMethod]
        public void TestDisconnect()
        {
            //Arrange
            IrisLib.ServiceChat expectedServiceChat = new IrisLib.ServiceChat();
            IrisLib.User user1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            IrisLib.User user2 = new IrisLib.User(121, "Tom", "Rifddle", "Marvolo", 53, "LordVolDeMort", "death");
            IrisLib.User user3 = new IrisLib.User(121, "Harry", "Potter", "ChildLived", 11, "HateLordVolDeMort", "Jinny");
            expectedServiceChat.currentlyConnectedUsers.Add(user1);
            expectedServiceChat.currentlyConnectedUsers.Add(user2);

            //Act
            expectedServiceChat.Disconnect(user1);
            bool exp1 = expectedServiceChat.currentlyConnectedUsers.Contains(user1);
            bool exp2 = true;
            try
            {
                expectedServiceChat.Disconnect(user3);
            }
            catch
            {
                exp2 = false;
            }

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
            Assert.IsFalse(exp1);
            Assert.IsTrue(exp2);
            Assert.IsTrue(exp3);
        }
    }
}
