using IrisLib;
using IrisClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisClient
{
    class ClientData: IServiceChatCallback
    {
        public static ServiceChatClient client;
        public static User CurrentUser;
        public static List<Chat> chats;
        public static Database database = new Database(true);
        public ClientData()
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            client.Connect(new User());
            //database.Update(client.SendDatabaseFirstTime());
        }

        public void DatabaseCallback(Database localDatabase)
        {
            database.Update(localDatabase);
        }
    }
}
