using System;
using System.Collections;
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

            SendMessage(user.Nickname + " подключился к чату!", 0, 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMessage(user.Nickname + " покинул чат!", 0, 0);
            }
        }

        public void SendMessage(string msg, int id, int chatID)
        {
            foreach (var item in users)
            {
                string answer = "===============\n";
                answer = DateTime.Now.ToString() + " | ";

                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += user.Nickname + " | " + "\n\t";
                }
                answer += msg;
                item.OperationContext.GetCallbackChannel<IServerChatCallback>().MessageCallback(answer, chatID);
            }
        }

        public User getUserFromList1(string login)
        {
            return Database.getUserFromList(login);
        }

        public User getUserFromList2(int id)
        {
            return Database.getUserFromList(id);
        }

        public Chat getChatFromList1(int id)
        {
            return Database.getChatFromList(id);
        }

        public Chat getChatFromList2(string name)
        {
            return Database.getChatFromList(name);
        }

        public bool getUsersFromDB()
        {
            return Database.getUsersFromDB();
        }

        public bool addUserToDB(User user)
        {
            return Database.addUserToDB(user);
        }

        public bool getChatsFromDB()
        {
            return Database.getChatsFromDB();
        }

        public bool changePassword(User user)
        {
            return Database.changePassword(user);
        }

        public bool addMessageToChat(Message message, Chat chat)
        {
            return Database.addMessageToChat(message, chat);
        }

        public bool addChatToDB(Chat chat)
        {
            return Database.addChatToDB(chat);
        }

        public void UpdateDB()
        {
            foreach (var item in users)
            {
                item.OperationContext.GetCallbackChannel<IServerChatCallback>().DBUpdateCallback(Database.Update());
            }
            
        }

        public List<Chat> getChats()
        {
            return Database.getChats();
        }

    }
}
