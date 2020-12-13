using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IrisLib
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    //[ServiceContract]
    public interface IServiceChat
    {
        [OperationContract(IsOneWay = true)]
        void Connect(User user);

        [OperationContract(IsOneWay = true)]
        void Disconnect(User user);

        [OperationContract(IsOneWay = true)]
        void SendDatabaseToClients();

        [OperationContract(IsOneWay = true)]
        void GetMessageFromClient(User sender, string messageText, int chatID);

        [OperationContract(IsOneWay = true)]
        void GetNewUser(User user);

        [OperationContract]
        Database SendDatabaseFirstTime();

        [OperationContract(IsOneWay = true)]
        void AddUserToChat(User sender, User user, int chatID);

        [OperationContract(IsOneWay = true)]
        void CreateNewChat(User sender, Chat chat);

        [OperationContract(IsOneWay = true)]
        void ChangePassword(User user);

        [OperationContract(IsOneWay = true)]
        void SendFileToHost(User sender, int chat, File file);
        [OperationContract(IsOneWay = true)]
        void GetFileFromHost(string filename, int userId);

        [OperationContract(IsOneWay = true)]
        void RemoveUserFromChat(int userID, int chatID);

        [OperationContract(IsOneWay = true)]
        void MakeUserInChatSilent(int userID, int chatID);

        [OperationContract(IsOneWay = true)]
        void MakeUserInChatNotSilent(int userID, int chatID);
    }



    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void DatabaseCallback(Database database);
        [OperationContract(IsOneWay = true)]
        void FileCallback(IrisLib.File file);
        [OperationContract(IsOneWay = true)]
        void UserIdCallback(int id);
    }
}
