using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestDatabase
    {
        IrisLib.Database expectedDatabase = new IrisLib.Database(true);

        private void initDB()
        {
            expectedDatabase.Users.Add(new IrisLib.User() { ID = 5, Login = "Pusja" });
            expectedDatabase.Users.Add(new IrisLib.User() { ID = 9, Login = "Kusja" });
            expectedDatabase.Chats.Add(new IrisLib.Chat(5, "Ranunculus"));
            expectedDatabase.Chats.Add(new IrisLib.Chat(7, "Violet"));

        }

        [TestMethod]
        public void TestGetUserFromList()
        {
            //Arrange
            initDB();

            //Act
            IrisLib.User user1 = expectedDatabase.GetUserFromList(5);
            IrisLib.User user2 = expectedDatabase.GetUserFromList(6);
            IrisLib.User user3 = expectedDatabase.GetUserFromList("Kusja");
            IrisLib.User user4 = expectedDatabase.GetUserFromList("Dusja");
            IrisLib.User user5 = expectedDatabase.GetUserFromList(null);

            //Assert
            Assert.IsNotNull(user1);
            Assert.IsNull(user2);
            Assert.IsNotNull(user3);
            Assert.IsNull(user4);
            Assert.IsNull(user5);
        }

        [TestMethod]
        public void TestGetChatFromList()
        {
            //Arrange
            initDB();

            //Act
            IrisLib.Chat chat1 = expectedDatabase.GetChatFromList(5);
            IrisLib.Chat chat2 = expectedDatabase.GetChatFromList(6);
            IrisLib.Chat chat3 = expectedDatabase.GetChatFromList("Violet");
            IrisLib.Chat chat4 = expectedDatabase.GetChatFromList("Galanthus");
            IrisLib.Chat chat5 = expectedDatabase.GetChatFromList(null);

            //Assert
            Assert.IsNotNull(chat1);
            Assert.IsNull(chat2);
            Assert.IsNotNull(chat3);
            Assert.IsNull(chat4);
            Assert.IsNull(chat5);
        }

        [TestMethod]
        public void TestAddUserToChat()
        {
            //Arrange
            initDB();
            IrisLib.User expectedUser = new IrisLib.User() { ID = 11 };

            //Act
            bool exp1 = expectedDatabase.AddUserToChat(expectedUser, 5);
            bool exp2 = expectedDatabase.AddUserToChat(expectedUser, 21);
            bool exp3 = expectedDatabase.AddUserToChat(null, 5);

            //Assert
            Assert.IsTrue(exp1);
            Assert.IsFalse(exp2);
            Assert.IsFalse(exp3);
        }

        [TestMethod]
        public void TestAddMessageToChat()
        {
            //Arrange
            initDB();
            IrisLib.Message expectedMessage = new IrisLib.Message(2, new IrisLib.User(), "i want some pizza");

            //Act
            bool exp1 = expectedDatabase.AddMessageToChat(expectedMessage, 5);
            bool exp2 = expectedDatabase.AddMessageToChat(expectedMessage, 21);
            bool exp3 = expectedDatabase.AddMessageToChat(null, 5);

            //Assert
            Assert.IsTrue(exp1);
            Assert.IsFalse(exp2);
            Assert.IsFalse(exp3);
        }

    }
}
