using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static Iris.IServiceChat;

namespace Iris
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        //all user's list
        List<User> users = new List<User>();
        //for generation id for users
        int nextId = 1;
        
        public int Connect(string name)
        {
            User user = new User()
            {
                ID = nextId,
                Nickname = name,
                OperationContext = OperationContext.Current
            };
            //creation new id
            //!need upgrade! 
            nextId++;

            SendMessage(user.Nickname + " подключился к чату!", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMessage(user.Nickname + " покинул чат!", 0);
            }
        }

        public void SendMessage(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = "===============\n";
                answer = DateTime.Now.ToString() + "| ";

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += user.Nickname + "| " + "\n\t";
                }
                answer += msg;
                item.OperationContext.GetCallbackChannel<IServerChatCallback>().MessageCallback(answer);
            }
        }

    }
}
