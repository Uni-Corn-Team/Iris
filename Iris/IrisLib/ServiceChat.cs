using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;

namespace IrisLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class ServiceChat : IServiceChat
    {
        public List<User> currentlyConnectedUsers = new List<User>();

        public User GetUserFromList(List<User> Users, int id)
        {
            for (int i = 0; i < Users.Count(); i++)
            {
                if (Users[i].ID == id)
                    return Users[i];
            }
            return null;
        }

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
            user.OperationContext.GetCallbackChannel<IServerChatCallback>().UserIdCallback(user.ID);
            Console.WriteLine();
        }

        public void Disconnect(User user)
        {
            Console.WriteLine("Remove");
            if (user != null)
            {
                Console.WriteLine(user.ToString());
                currentlyConnectedUsers.Remove(user);
            }
            Console.WriteLine();
        }

        public void SendDatabaseToClients()
        {
            Console.WriteLine("SendDatabaseToClients");
            foreach (var user in currentlyConnectedUsers)
            {
                user.OperationContext.GetCallbackChannel<IServerChatCallback>().DatabaseCallback(database);
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine();
        }

        public void GetMessageFromClient(User sender, string messageText, int chatID)
        {
            Console.WriteLine("GetMessageFromClient");
            Console.WriteLine("Sender: " + sender.ToString() + "Message: " + messageText + "\nChat id: " + chatID);
            Message message = new Message(0, sender, messageText);
            database.AddMessageToChat(message, chatID);
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public void GetNewUser(User user)
        {
            Console.WriteLine("GetNewUser");
            Console.WriteLine("New user: " + user.ToString());
            database.AddUserToDB(user);
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public void AddUserToChat(User sender, User user, int chatID)
        {
            Console.WriteLine("AddUserToChat");
            Console.WriteLine("Sender: " + sender.ToString() + user.ToString() + "Chat id: " + chatID);

            string textMes = user.Nickname + " теперь с нами";
            Message mes = new Message(chatID, user, textMes, DateTime.Now);
            database.AddMessageToChat(mes, chatID);


            database.AddUserToChat(user, chatID);
            SendDatabaseToClients();
            Console.WriteLine();

        }

        public void CreateNewChat(User sender, Chat chat)
        {
            Console.WriteLine("CreateNewChat");
            Console.WriteLine("Sender: " + sender.ToString() + "Chat: " + chat.ToString());
            database.AddChatToDB(chat);
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public void ChangePassword(User user)
        {
            Console.WriteLine("ChangePassword");
            Console.WriteLine("User: " + user.ToString());
            database.ChangePassword(user);
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public Database SendDatabaseFirstTime()
        {
            Console.WriteLine("SendDatabaseFirstTime");
            Console.WriteLine();
            return database;
        }

        public void SendFileToHost(User sender, int chatId, File file)
        {
            Console.WriteLine("SendFileToHost");
            string textMes = sender.Name + " send file: " + file.Name;
            Message mes = new Message(chatId, sender, textMes, DateTime.Now, file.Name);
            database.AddMessageToChat(mes, chatId);
            Console.WriteLine("Sender: " + sender.ToString() + "Chatd id: " + chatId);
            using (FileStream fs = new FileStream("..\\..\\Files\\" + database.GetChatFromList(chatId).Name + "\\" + file.Name, FileMode.OpenOrCreate))
            {
                Console.WriteLine("Sending file: " + file.Name);
                fs.Write(file.Binary, 0, file.Binary.Length);
            }
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public void GetFileFromHost(string filename, int userId, int chatID)
        {
            Console.WriteLine("GetFileToHost");
            IrisLib.File file = new File();
            file.Name = filename;
            try
            {
                using (FileStream fs = new FileStream("..\\..\\Files\\" + database.GetChatFromList(chatID).Name + "\\" + file.Name, FileMode.Open, FileAccess.Read))
                {
                    Console.WriteLine("Read file: " + file.Name);
                    file.Binary = new Byte[fs.Length];
                    Console.WriteLine("Readen bytes: " + fs.Read(file.Binary, 0, (int)fs.Length));
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            
            Console.WriteLine(GetUserFromList(currentlyConnectedUsers, userId).ToString());
            try
            {
                Console.WriteLine("User: " + GetUserFromList(currentlyConnectedUsers, userId).ToString());
                GetUserFromList(currentlyConnectedUsers, userId).OperationContext.GetCallbackChannel<IServerChatCallback>().FileCallback(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public void RemoveUserFromChat(int userID, int chatID, bool isKicked)
        {
            Console.WriteLine("RemoveUserFromChat");
            Console.WriteLine("User id: " + userID + " Chat id: " + chatID);

            string textMes;
            if (isKicked)
            {
                textMes = database.GetUserFromList(userID).Nickname + " был изгнан";
            }
            else
            {
                textMes = database.GetUserFromList(userID).Nickname + " покинул нас";
            }
            Message mes = new Message(chatID, database.GetUserFromList(userID), textMes, DateTime.Now);
            database.AddMessageToChat(mes, chatID);

            database.RemoveUserFromChat(userID, chatID);
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public void MakeUserInChatSilent(int userID, int chatID)
        {
            Console.WriteLine("MakeUserInChatSilent");
            Console.WriteLine("User id: " + userID + " Chat id: " + chatID);

            string textMes = database.GetUserFromList(userID).Nickname + " теперь молчит";
            Message mes = new Message(chatID, database.GetUserFromList(userID), textMes, DateTime.Now);
            database.AddMessageToChat(mes, chatID);

            database.MakeUserInChatSilent(userID, chatID);
            SendDatabaseToClients();
            Console.WriteLine();
        }

        public void MakeUserInChatNotSilent(int userID, int chatID)
        {
            Console.WriteLine("MakeUserInChatNotSilent");
            Console.WriteLine("User id: " + userID + " Chat id: " + chatID);

            string textMes = database.GetUserFromList(userID).Nickname + " снова заговорит";
            Message mes = new Message(chatID, database.GetUserFromList(userID), textMes, DateTime.Now);
            database.AddMessageToChat(mes, chatID);

            database.MakeUserInChatNotSilent(userID, chatID);
            SendDatabaseToClients();
            Console.WriteLine();
        }
    }
}
