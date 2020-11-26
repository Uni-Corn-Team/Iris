using IrisLib;
using IrisClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisClient
{
    class ClientData
    {
        public static ServiceChatClient client;
        public static User CurrentUser;
        public static List<Chat> chats;
        public static Database database = new Database();
        public ClientData()
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            database.Update(client.SendDatabaseFirstTime());
        }
    }
}
