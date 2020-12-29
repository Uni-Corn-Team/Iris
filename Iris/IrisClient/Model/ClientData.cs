using IrisLib;
using IrisClient.ServiceChat;
using System;
using System.Collections.Generic;
using System.IO;

namespace IrisClient
{
    /// <summary>
    /// Класс, описывающий модель данных клиента.
    /// </summary>
    class ClientData: ServiceChat.IServiceChatCallback
    {
        /// <summary>
        /// Клиент.
        /// </summary>
        public static ServiceChatClient client;

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public static User CurrentUser = new User();

        /// <summary>
        /// Список чатов, в которых состоит текущий пользователь.
        /// </summary>
        public static List<Chat> chats;

        /// <summary>
        /// Локальный экземпляр базы данных.
        /// </summary>
        public static Database database = new Database(true);

        /// <summary>
        /// Экземпляр главного окна приложения.
        /// </summary>
        public static MainWindow mainWindow = new MainWindow();

        /// <summary>
        /// Флаг для определения события закрытия приложения.
        /// </summary>
        public static bool isClose = true;

        /// <summary>
        /// Идентификатор текущего пользователя на сервере.
        /// </summary>
        public static int idOnServer = -1;
        
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public ClientData()
        {
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            client.Connect(new User());
        }

        /// <summary>
        /// Метод для получения базы данных от сервера.
        /// </summary>
        /// <param name="localDatabase"> получаемая база данных </param>
        public void DatabaseCallback(Database localDatabase)
        {
            try
            {
                int ID = -1;
                if (CurrentUser.CurrentChatID != -1)
                {
                    ID = CurrentUser.CurrentChatID;
                    CurrentUser.CurrentChatID = -1;
                    mainWindow.lCurrentChatName.Content = "";
                }
                database.Update(localDatabase);
                if (ID != -1 && database.GetChatFromList(ID).IsUserInChat(CurrentUser))
                {
                    CurrentUser.CurrentChatID = ID;
                    mainWindow.lCurrentChatName.Content = database.GetChatFromList(CurrentUser.CurrentChatID).Name;
                }
                mainWindow.Redraw();
            }
            catch (Exception)
            {
                database.Update(localDatabase);
            }
        }

        /// <summary>
        /// Метод для открытия главного окна приложения.
        /// </summary>
        public static void ShowMainWindow()
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

        /// <summary>
        /// Метод для получения файла с сервера.
        /// </summary>
        /// <param name="file"> получаемый файл </param>
        public void FileCallback(IrisLib.File file)
        {
            try
            {
                if (!Directory.Exists("..\\..\\Downloads\\" + database.GetChatFromList(CurrentUser.CurrentChatID).Name))
                {
                    Directory.CreateDirectory("..\\..\\Downloads\\" + database.GetChatFromList(CurrentUser.CurrentChatID).Name);
                }
                using (FileStream fs = new FileStream("..\\..\\Downloads\\" + database.GetChatFromList(CurrentUser.CurrentChatID).Name + "\\" + file.Name, FileMode.OpenOrCreate))
                {
                    Console.WriteLine(file.Name);
                    fs.Write(file.Binary, 0, file.Binary.Length);
                }
            }
            catch { }
        }

        /// <summary>
        /// Метод для получения идентификатора пользователя от сервера.
        /// </summary>
        /// <param name="id"> получаемый идентификатор пользователя </param>
        public void UserIdCallback(int id)
        {
            idOnServer = id;
        }
    }
}
