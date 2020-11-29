using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestChat
    {
        [TestMethod]
        public void TestIsUserInChat()
        {
            //Arrange
            IrisLib.User expectedUser = new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123");
            IrisLib.Chat expectedChat = new IrisLib.Chat(1469, "Cheboksary");
            expectedChat.Members.Add(new IrisLib.User());
            expectedChat.Members.Add(new IrisLib.User() { ID = 2 });
            expectedChat.Members.Add(new IrisLib.User() { ID = 5 });
            expectedChat.Members.Add(new IrisLib.User() { ID = 7 });
            expectedChat.Members.Add(new IrisLib.User(111, "Ivan", "Vinogradov", "FunnySurname", 0, "Vina", "qwerty123"));
            expectedChat.Members.Add(new IrisLib.User() { ID = 4 });
            expectedChat.Members.Add(new IrisLib.User() { ID = 9 });
            //Act
            bool isUserInChat = expectedChat.IsUserInChat(expectedUser);

            //Assert
            Assert.AreEqual(isUserInChat, true);

        }
    }
}
