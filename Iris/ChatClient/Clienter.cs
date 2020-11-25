using Iris;
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


    }
}
