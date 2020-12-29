using System.ServiceModel;

namespace IrisLib
{
    /// <summary>
    /// Интерфейс, описывающий работу сервера.
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        /// <summary>
        /// Метод соединения пользователя с сервером.
        /// </summary>
        /// <param name="user"> подключаемый пользователь </param>
        [OperationContract(IsOneWay = true)]
        void Connect(User user);

        /// <summary>
        /// Метод отключения пользователя от сервера.
        /// </summary>
        /// <param name="user"> отключаемый пользователь </param>
        [OperationContract(IsOneWay = true)]
        void Disconnect(User user);

        /// <summary>
        /// Метод отправки базы данных всем клиентам.
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void SendDatabaseToClients();

        /// <summary>
        /// Метод получения сервером сообщения от клиента.
        /// </summary>
        /// <param name="sender"> отправитель сообщения </param>
        /// <param name="messageText"> текст сообщения </param>
        /// <param name="chatID"> идентификатор чата, в который отправлено сообщение </param>
        [OperationContract(IsOneWay = true)]
        void GetMessageFromClient(User sender, string messageText, int chatID);

        /// <summary>
        /// Метод получения (регитрации) нового пользователя.
        /// </summary>
        /// <param name="user"> регистрируемый пользователь </param>
        [OperationContract(IsOneWay = true)]
        void GetNewUser(User user);

        /// <summary>
        /// Метод для первой отправке базы данных клиенту.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Database SendDatabaseFirstTime();

        /// <summary>
        /// Метод для добавления пользователя в чат.
        /// </summary>
        /// <param name="sender"> администратор чата </param>
        /// <param name="user"> добавляемый пользователь </param>
        /// <param name="chatID"> идентификатор чата, в который происходит добавление </param>
        [OperationContract(IsOneWay = true)]
        void AddUserToChat(User sender, User user, int chatID);

        /// <summary>
        /// Метод для осздания нового чата.
        /// </summary>
        /// <param name="sender"> создатель (администратор) чата </param>
        /// <param name="chat"> создаваемый чат </param>
        [OperationContract(IsOneWay = true)]
        void CreateNewChat(User sender, Chat chat);

        /// <summary>
        /// Метод для изменения пароля пользователя.
        /// </summary>
        /// <param name="user"> редактируемый пользователь </param>
        [OperationContract(IsOneWay = true)]
        void ChangePassword(User user);

        /// <summary>
        /// Метод для отправки файла на сервер.
        /// </summary>
        /// <param name="sender"> отправитель </param>
        /// <param name="chat"> чат, в котором отправили файл </param>
        /// <param name="file"> отправляемый файл </param>
        [OperationContract(IsOneWay = true)]
        void SendFileToHost(User sender, int chat, File file);
        
        /// <summary>
        /// Метод для отправки файла с сервера.
        /// </summary>
        /// <param name="filename"> имя отправляемого файла </param>
        /// <param name="userId"> идентификатор пользователя, запросившего файл </param>
        /// <param name="chatID"> идентификатор чата, в котором находится файл </param>
        [OperationContract(IsOneWay = true)]
        void GetFileFromHost(string filename, int userId, int chatID);

        /// <summary>
        /// Метод для удаления пользователя из чата.
        /// </summary>
        /// <param name="userID"> идентификатор удаляемого пользователя </param>
        /// <param name="chatID"> идентификатор чата, из которого удаляется пользователь </param>
        /// <param name="isKicked"> флаг, был пользователь удален кем-то или самостоятельно </param>
        [OperationContract(IsOneWay = true)]
        void RemoveUserFromChat(int userID, int chatID, bool isKicked);

        /// <summary>
        /// Метод для блокировки отправки сообщений пользователем в конкретный чат.
        /// </summary>
        /// <param name="userID"> идентификатор блокируемого пользователя </param>
        /// <param name="chatID"> идентификатор чата, в котором пользователя блокируют </param>
        [OperationContract(IsOneWay = true)]
        void MakeUserInChatSilent(int userID, int chatID);

        /// <summary>
        /// Метод для разблокировки отправки сообщений пользователем в конкретный чат.
        /// </summary>
        /// <param name="userID"> идентификатор пользователя </param>
        /// <param name="chatID"> идентификатор чата, в котором пользователя разблокируют </param>
        [OperationContract(IsOneWay = true)]
        void MakeUserInChatNotSilent(int userID, int chatID);
    }

    /// <summary>
    /// Интерфейс, описывающий работу клиента.
    /// </summary>
    public interface IServerChatCallback
    {
        /// <summary>
        /// Метод для получения базы данных от сервера.
        /// </summary>
        /// <param name="database"> получаемая база данных </param>
        [OperationContract(IsOneWay = true)]
        void DatabaseCallback(Database database);

        /// <summary>
        /// Метод для получения файла с сервера.
        /// </summary>
        /// <param name="file"> получаемый файл </param>
        [OperationContract(IsOneWay = true)]
        void FileCallback(IrisLib.File file);

        /// <summary>
        /// Метод для получения идентификатора пользователя от сервера.
        /// </summary>
        /// <param name="id"> получаемый идентификатор пользователя </param>
        [OperationContract(IsOneWay = true)]
        void UserIdCallback(int id);
    }
}
