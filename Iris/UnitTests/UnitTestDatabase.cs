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
            expectedDatabase.Users.Clear();
            expectedDatabase.Chats.Clear();
            expectedDatabase.Users.Add(new IrisLib.User() { ID = 5, Login = "Pusja" });
            expectedDatabase.Users.Add(new IrisLib.User() { ID = 9, Login = "Kusja" });
            expectedDatabase.Chats.Add(new IrisLib.Chat(5, "Ranunculus"));
            expectedDatabase.Chats.Add(new IrisLib.Chat(7, "Violet"));

        }

        [TestMethod]
        public void TestGetUserFromListByExistingUserID()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.User user1 = expectedDatabase.GetUserFromList(5);
            //Assert
            Assert.IsNotNull(user1);
        }

        [TestMethod]
        public void TestGetUserFromListByNonexistingUserID()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.User user2 = expectedDatabase.GetUserFromList(6);
            //Assert
            Assert.IsNull(user2);
        }

        [TestMethod]
        public void TestGetUserFromListByExistingUserLogin()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.User user3 = expectedDatabase.GetUserFromList("Kusja");
            //Assert
            Assert.IsNotNull(user3);
        }

        [TestMethod]
        public void TestGetUserFromListByNonexistingUserLogin()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.User user4 = expectedDatabase.GetUserFromList("Dusja");
            //Assert
            Assert.IsNull(user4);
        }

        [TestMethod]
        public void TestGetUserFromListByNull()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.User user5 = expectedDatabase.GetUserFromList(null);
            //Assert
            Assert.IsNull(user5);
        }

        [TestMethod]
        public void TestGetChatFromListByExistingChatID()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.Chat chat1 = expectedDatabase.GetChatFromList(5);
            //Assert
            Assert.IsNotNull(chat1);
        }

        [TestMethod]
        public void TestGetChatFromListByUnexistingChatID()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.Chat chat2 = expectedDatabase.GetChatFromList(6);
            //Assert
            Assert.IsNull(chat2);
        }

        [TestMethod]
        public void TestGetChatFromListByExistingChatName()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.Chat chat3 = expectedDatabase.GetChatFromList("Violet");
            //Assert
            Assert.IsNotNull(chat3);
        }

        [TestMethod]
        public void TestGetChatFromListByNonexistingChatName()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.Chat chat4 = expectedDatabase.GetChatFromList("Galanthus");
            //Assert
            Assert.IsNull(chat4);
        }

        [TestMethod]
        public void TestGetChatFromListByNull()
        {
            //Arrange
            initDB();
            //Act
            IrisLib.Chat chat5 = expectedDatabase.GetChatFromList(null);
            //Assert
            Assert.IsNull(chat5);
        }

        [TestMethod]
        public void TestAddUserToChatByExistingChatID()
        {
            //Arrange
            initDB();
            IrisLib.User expectedUser = new IrisLib.User() { ID = 11 };
            //Act
            bool exp1 = expectedDatabase.AddUserToChat(expectedUser, 5);
            //Assert
            Assert.IsTrue(exp1);
        }

        [TestMethod]
        public void TestAddUserToChatByNonexistingChatID()
        {
            //Arrange
            initDB();
            IrisLib.User expectedUser = new IrisLib.User() { ID = 11 };
            //Act
            bool exp2 = expectedDatabase.AddUserToChat(expectedUser, 21);
            //Assert
            Assert.IsFalse(exp2);
        }

        [TestMethod]
        public void TestAddUserToChatNullUser()
        {
            //Arrange
            initDB();
            IrisLib.User expectedUser = new IrisLib.User() { ID = 11 };
            //Act
            bool exp3 = expectedDatabase.AddUserToChat(null, 5);
            //Assert
            Assert.IsFalse(exp3);
        }

        [TestMethod]
        public void TestAddUserToChatAlreadyAddedUser()
        {
            //Arrange
            initDB();
            IrisLib.User expectedUser = new IrisLib.User() { ID = 11 };
            //Act
            expectedDatabase.AddUserToChat(expectedUser, 5);
            bool exp4 = expectedDatabase.AddUserToChat(expectedUser, 5);
            //Assert
            Assert.IsFalse(exp4);
        }

        [TestMethod]
        public void TestAddMessageToChatByExistingChatID()
        {
            //Arrange
            initDB();
            IrisLib.Message expectedMessage = new IrisLib.Message(2, new IrisLib.User(), "i want some pizza");
            //Act
            bool exp1 = expectedDatabase.AddMessageToChat(expectedMessage, 5);
            //Assert
            Assert.IsTrue(exp1);
        }

        [TestMethod]
        public void TestAddMessageToChatByNonexistingChatID()
        {
            //Arrange
            initDB();
            IrisLib.Message expectedMessage = new IrisLib.Message(2, new IrisLib.User(), "i want some pizza");
            //Act
            bool exp2 = expectedDatabase.AddMessageToChat(expectedMessage, 21);
            //Assert
            Assert.IsFalse(exp2);
        }

        [TestMethod]
        public void TestAddMessageToChatNullMessage()
        {
            //Arrange
            initDB();
            IrisLib.Message expectedMessage = new IrisLib.Message(2, new IrisLib.User(), "i want some pizza");
            //Act
            bool exp3 = expectedDatabase.AddMessageToChat(null, 5);
            //Assert
            Assert.IsFalse(exp3);
        }

        [TestMethod]
        public void TestUpdateByEmptyDB()
        {
            //Arrange
            initDB();

            //Act
            expectedDatabase.Update(new IrisLib.Database(true));
            bool exp1 = expectedDatabase.Users.Count == 0;
            bool exp2 = expectedDatabase.Chats.Count == 0;
            bool exp3 = expectedDatabase.UsersCountAsNextID == 0;
            bool exp4 = expectedDatabase.ChatsCountAsNextID == 0;
            bool exp5 = expectedDatabase.MessagesCountAsNextID == 0;

            //Assert
            Assert.IsTrue(exp1);
            Assert.IsTrue(exp2);
            Assert.IsTrue(exp3);
            Assert.IsTrue(exp4);
            Assert.IsTrue(exp5);
        }


        [TestMethod]
        public void TestUpdateByNotEmptyDB()
        {
            //Arrange
            initDB();
            IrisLib.Database expectedDatabase1 = new IrisLib.Database(true);
            expectedDatabase1.Users.Add(new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123"));

            //Act
            expectedDatabase.Update(expectedDatabase1);
            bool exp6 = expectedDatabase.Users.Count == 1;

            //Assert
            Assert.IsTrue(exp6);
        }

        [TestMethod]
        public void TestUpdateByNullDB()
        {
            //Arrange
            initDB();

            //Act
            bool exp7 = true;
            try
            {
                expectedDatabase.Update(null);
            }
            catch
            {
                exp7 = false;
            }

            //Assert
            Assert.IsTrue(exp7);
        }
    }
}
