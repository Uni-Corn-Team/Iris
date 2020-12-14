using IrisLib;
using IrisClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.IO;

namespace IrisClient
{
    class ClientData: ServiceChat.IServiceChatCallback
    {
        public static ServiceChatClient client;
        public static User CurrentUser = new User();
        public static List<Chat> chats;
        public static Database database = new Database(true);
        public static MainWindow mainWindow = new MainWindow();
        public static bool isClose = true;
        public static int idOnServer = -1;
        
        public ClientData()
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            client.Connect(new User());
        }

        public void DatabaseCallback(Database localDatabase)
        {
            try
            {
                int ID = -1;
                if (CurrentUser.CurrentChatID != -1)
                {
                    ID = CurrentUser.CurrentChatID;
                    CurrentUser.CurrentChatID = -1;
                    mainWindow.lCurrentChatName.Content = "";
                }
                database.Update(localDatabase);
                if (ID != -1 && database.GetChatFromList(ID).IsUserInChat(CurrentUser))
                {
                    CurrentUser.CurrentChatID = ID;
                    mainWindow.lCurrentChatName.Content = database.GetChatFromList(CurrentUser.CurrentChatID).Name;
                }
                mainWindow.Redraw();
            }
            catch (Exception)
            {
                database.Update(localDatabase);
            }
        }

        public static void ShowMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

        public void FileCallback(IrisLib.File file)
        {
            try
            {
                if (!Directory.Exists("..\\..\\Downloads\\" + database.GetChatFromList(CurrentUser.CurrentChatID).Name))
                {
                    Directory.CreateDirectory("..\\..\\Downloads\\" + database.GetChatFromList(CurrentUser.CurrentChatID).Name);
                }
                using (FileStream fs = new FileStream("..\\..\\Downloads\\" + database.GetChatFromList(CurrentUser.CurrentChatID).Name + "\\" + file.Name, FileMode.OpenOrCreate))
                {
                    Console.WriteLine(file.Name);
                    fs.Write(file.Binary, 0, file.Binary.Length);
                }
            }
            catch { }
        }

        public void UserIdCallback(int id)
        {
            idOnServer = id;
        }
    }
}
