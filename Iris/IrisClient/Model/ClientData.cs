using IrisLib;
using IrisClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // idOnServer = client.Connect(new User());
            client.Connect(new User());
            //database.Update(client.SendDatabaseFirstTime());
        }

        public void DatabaseCallback(Database localDatabase)
        {
            //database.Update(localDatabase);

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

            using (FileStream fs = new FileStream("..\\..\\Downloads\\" + file.Name, FileMode.OpenOrCreate))
            {
                Console.WriteLine(file.Name);
                fs.Write(file.Binary, 0, file.Binary.Length);
            }
        }

        public void UserIdCallback(int id)
        {
            idOnServer = id;
        }
    }
}
