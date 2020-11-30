using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTestMainWindow
    {
        [TestMethod]
        public void TestChangePassword()
        {
            IrisClient.MainWindow mainWindow = new IrisClient.MainWindow();
        }
    }
}
