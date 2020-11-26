using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;

namespace IrisLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<User> currentlyConnectedUsers = new List<User>();

        User user = new User(123, "name", "surname", "nickname", 20, "login", "password");
        /*
        public void doWork()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, user);

            }
        }

        public int Connect(string name)
        {
            User user = new User()
            {
                ID = 1,
                Nickname = name,
                OperationContext = OperationContext.Current
            };

            //SendMessage(user.Nickname + " подключился к чату!", 0, 0);
            currentlyConnectedUsers.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = currentlyConnectedUsers.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                currentlyConnectedUsers.Remove(user);
                //SendMessage(user.Nickname + " покинул чат!", 0, 0);
            }
        }
        */

        Database database = new Database();
        public void Connect(User user)
        {
            currentlyConnectedUsers.Add(user);
        }

        public void Disconnect(User user)
        {
            currentlyConnectedUsers.Remove(user);
        }

        public void SendDatabaseToClients()
        {
            foreach (var user in currentlyConnectedUsers)
            {
                user.OperationContext.GetCallbackChannel<IServerChatCallback>().DatabaseCallback(database);
            }
        }

        public void GetMessageFromClient(User sender, string messageText, int chatID)
        {
            Message message = new Message(0, sender, messageText);
            database.AddMessageToChat(message, chatID);
            SendDatabaseToClients();
        }

        public void GetNewUser(User user)
        {
            database.AddUserToDB(user);
            SendDatabaseToClients();
        }

        public void AddUserToChat(User sender, User user, int chatID)
        {
            database.AddUserToChat(user, chatID);
            SendDatabaseToClients();
        }

        public void CreateNewChat(User sender, User user, Chat chat)
        {
            database.AddChatToDB(chat);
            SendDatabaseToClients();
        }
    }
}
