using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestChat
    {
        IrisLib.Chat expectedChat = new IrisLib.Chat(1469, "Cheboksary");

        private void initChat()
        {
            expectedChat.Members.Clear();
            expectedChat.Members.Add(new IrisLib.User());
            expectedChat.Members.Add(new IrisLib.User() { ID = 2 });
            expectedChat.Members.Add(new IrisLib.User() { ID = 5 });
            expectedChat.Members.Add(new IrisLib.User() { ID = 7 });
            expectedChat.Members.Add(new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123"));
            expectedChat.Members.Add(new IrisLib.User() { ID = 4 });
            expectedChat.Members.Add(new IrisLib.User() { ID = 9 });
        }

        [TestMethod]
        public void TestIsUserInChatByExistingUser()
        {
            //Arrange
            IrisLib.User expectedUser1 = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            initChat();
            
            //Act
            bool isUserInChat1 = expectedChat.IsUserInChat(expectedUser1);

            //Assert
            Assert.IsTrue(isUserInChat1);
        }

        [TestMethod]
        public void TestIsUserInChatByNonexistingUser()
        {
            //Arrange
            IrisLib.User expectedUser2 = new IrisLib.User() { ID = 354 };
            initChat();

            //Act
            bool isUserInChat2 = expectedChat.IsUserInChat(expectedUser2);

            //Assert
            Assert.IsFalse(isUserInChat2);
        }

        [TestMethod]
        public void TestIsUserInChatByNull()
        {
            //Arrange
            initChat();

            //Act
            bool isUserInChat3 = expectedChat.IsUserInChat(null);

            //Assert
            Assert.IsFalse(isUserInChat3);
        }
    }
}
