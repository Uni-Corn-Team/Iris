using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IrisLib
{
    [ServiceContract]
    public interface IServiceChat
    {
       //[OperationContract]
        //void doWork();

        //[OperationContract]
        //int Connect(string name);

        //[OperationContract]
        //void Disconnect(int id);

        [OperationContract]
        void Connect(User user);

        [OperationContract]
        void Disconnect(User user);

        [OperationContract(IsOneWay = true)]
        void SendDatabaseToClients();

        [OperationContract(IsOneWay = true)]
        void GetMessageFromClient(User sender, string messageText, int chatID);

        [OperationContract(IsOneWay = true)]
        void GetNewUser(User user);

        [OperationContract(IsOneWay = true)]
        void AddUserToChat(User sender, User user, int chatID);

        [OperationContract(IsOneWay = true)]
        void CreateNewChat(User sender, User user, Chat chat);
    }


    public interface IServerChatCallback
    {

        //[OperationContract(IsOneWay = true)]
        //void DoWorkCallback(MemoryStream ms);

        [OperationContract(IsOneWay = true)]
        void DatabaseCallback(Database database);
    }
}
