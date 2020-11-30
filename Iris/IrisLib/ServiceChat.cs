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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class ServiceChat : IServiceChat
    {
        public List<User> currentlyConnectedUsers = new List<User>();
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

        int nextId = 1;
        public void Connect(User user)
        {
            user.ID = nextId;
            nextId++;
            Console.WriteLine("Connect");
            Console.WriteLine(user.ToString());
            user.OperationContext = OperationContext.Current;
            user.OperationContext.GetCallbackChannel<IServerChatCallback>().DatabaseCallback(database);
            currentlyConnectedUsers.Add(user);
        }

        public void Disconnect(User user)
        {
            Console.WriteLine("Remove");
            Console.WriteLine(user.ToString());
            currentlyConnectedUsers.Remove(user);
        }

        public void SendDatabaseToClients()
        {
            Console.WriteLine("SendDatabaseToClients");
            foreach (var user in currentlyConnectedUsers)
            {
                user.OperationContext.GetCallbackChannel<IServerChatCallback>().DatabaseCallback(database);
                Console.WriteLine(user.ToString());
            }
        }

        public void GetMessageFromClient(User sender, string messageText, int chatID)
        {
            Console.WriteLine("GetMessageFromClient");
            Console.WriteLine(sender.ToString() + messageText + "\nChat id: " + chatID);
            Message message = new Message(0, sender, messageText);
            database.AddMessageToChat(message, chatID);
            SendDatabaseToClients();
        }

        public void GetNewUser(User user)
        {
            Console.WriteLine("GetNewUser");
            Console.WriteLine(user.ToString());
            database.AddUserToDB(user);
            SendDatabaseToClients();
        }

        public void AddUserToChat(User sender, User user, int chatID)
        {
            Console.WriteLine("AddUserToChat");
            Console.WriteLine(sender.ToString() + user.ToString() + "Chat id: " + chatID);
            database.AddUserToChat(user, chatID);
            SendDatabaseToClients();

        }

        public void CreateNewChat(User sender, Chat chat)
        {
            Console.WriteLine("CreateNewChat");
            Console.WriteLine(sender.ToString() + chat.ToString());
            database.AddChatToDB(chat);
            SendDatabaseToClients();
        }

        public void ChangePassword(User user)
        {
            Console.WriteLine("ChangePassword");
            Console.WriteLine(user.ToString());
            database.ChangePassword(user);
            SendDatabaseToClients();
        }

        public Database SendDatabaseFirstTime()
        {
            Console.WriteLine("SendDatabaseFirstTime");
            return database;
        }
    }
}
