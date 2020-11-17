using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IrisLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        List<User> currentlyConnectedUsers = new List<User>();
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
