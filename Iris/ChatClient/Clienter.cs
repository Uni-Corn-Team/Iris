using ChatClient.HelperClasses;
using ChatClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Clienter
    {
        public static ServiceChatClient client;

        public Clienter()
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
        }

        public static List<Chat> ConvertObjectArrArrToListChat(object[][] mass)
        {
            List<Chat> list = new List<Chat>();
            for(int i = 0; i < mass.Length; i++)
            {
                list.Add(Chat.Disconvert(mass[i]));
            }
            return list;
        }
    }
}
