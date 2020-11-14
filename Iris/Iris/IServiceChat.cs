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
        ArrayList getUserFromList1(string login);
        [OperationContract]
        ArrayList getUserFromList2(int id);
        [OperationContract]
        ArrayList getChatFromList1(int id);
        [OperationContract]
        ArrayList getChatFromList2(string name);
        [OperationContract]
        bool getUsersFromDB();
        [OperationContract]
        bool addUserToDB(ArrayList user);
        [OperationContract]
        bool getChatsFromDB();
        [OperationContract]
        bool changePassword(ArrayList user);
        [OperationContract]
        bool addMessageToChat(ArrayList message, ArrayList chat);
        [OperationContract]
        bool addChatToDB(ArrayList chat);
        [OperationContract]
        bool UpdateDB();
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
    }

}