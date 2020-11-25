using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Iris
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        /// <summary>
        /// Connect user to server
        /// </summary>
        /// <param name="name">user name</param>
        /// <returns>user's id</returns>
        [OperationContract]
        int Connect(string name);

        /// <summary>
        /// Disconnect from server
        /// </summary>
        /// <param name="id"></param>
        [OperationContract]
        void Disconnect(int id);

        /// <summary>
        /// send message to server
        /// </summary>
        /// <param name="message">user's message</param>
        /// <param name="id">user's id</param>
        /// <param name="chat">chat owner of message</param>
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, int id, int chatID);

        [OperationContract]
        User getUserFromList1(string login);
        [OperationContract]
        User getUserFromList2(int id);
        [OperationContract]
        Chat getChatFromList1(int id);
        [OperationContract]
        Chat getChatFromList2(string name);
        [OperationContract]
        bool getUsersFromDB();
        [OperationContract]
        bool addUserToDB(User user);
        [OperationContract]
        bool getChatsFromDB();
        [OperationContract]
        bool changePassword(User user);
        [OperationContract]
        bool addMessageToChat(Message message, Chat chat);
        [OperationContract]
        bool addChatToDB(Chat chat);

        [OperationContract(IsOneWay = true)]
        void UpdateDB();



        [OperationContract]
        List<Chat> getChats();
    }

    public interface IServerChatCallback
    {
        /// <summary>
        /// get messages from server
        /// </summary>
        /// <param name="message"></param>
        /// /// <param name="chat">chat owner of message</param>
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message, int chatID);

        [OperationContract(IsOneWay = true)]
        void DBUpdateCallback(bool isUpdated);
    }

}