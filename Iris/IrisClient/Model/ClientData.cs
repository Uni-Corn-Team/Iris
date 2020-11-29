using IrisLib;
using IrisClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisClient
{
    class ClientData: ServiceChat.IServiceChatCallback
    {
        public static ServiceChatClient client;
        public static User CurrentUser = new User();
        public static List<Chat> chats;
        public static Database database = new Database(true);
        public static MainWindow mainWindow = new MainWindow();

        public ClientData()
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            client.Connect(new User());
            //database.Update(client.SendDatabaseFirstTime());
        }

        public void DatabaseCallback(Database localDatabase)
        {
            //database.Update(localDatabase);

            try
            {
                int ID = -1;
                if (ClientData.CurrentUser.CurrentChatID != -1)
                {
                    ID = ClientData.CurrentUser.CurrentChatID;
                }
                ClientData.database.Update(localDatabase);
                if (ID != -1)
                {
                    ClientData.CurrentUser.CurrentChatID = ID;
                }

                mainWindow.RedrawCurrentChat();

            }
            catch (Exception)
            {
                ClientData.database.Update(localDatabase);
            }
        }

        public static void ShowMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
