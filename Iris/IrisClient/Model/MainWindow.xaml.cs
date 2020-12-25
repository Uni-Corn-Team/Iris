using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using IrisLib;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ServiceChat.IServiceChatCallback
    {
        /// <summary>
        /// Флаг наличия открытого окна ChangePassword.
        /// </summary>
        public static bool isWindowOpenChangePassword = false;

        /// <summary>
        /// Флаг наличия открытого окна AddUser.
        /// </summary>
        public static bool isWindowOpenAddUser = false;

        /// <summary>
        /// Флаг наличия открытого окна CreateChat.
        /// </summary>
        public static bool isWindowOpenCreateChat = false;

        /// <summary>
        /// Индекс выбранного в списке пользователя.
        /// </summary>
        private int selectedUserID = -1;

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ClientData.CurrentUser.CurrentChatID = -1;
            ClientData.chats = new List<Chat>();
            foreach (Chat dialog in ClientData.database.Chats)
            {
                if (dialog.IsUserInChat(ClientData.CurrentUser))
                {
                    ClientData.chats.Add(dialog);
                    lbDialogs.Items.Add(dialog.Name);
                }
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Выход".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            ClientData.CurrentUser = new User();
            ClientData.CurrentUser.ID = -1;
            ClientData.chats.Clear();
            new SignInWindow().Show();
            ClientData.isClose = false;
            this.Close();
        }

        /// <summary>
        /// Метод переотрисовки окна.
        /// Нужен для обновления списков чатов, сообщений, участников чата.
        /// Вызывается после получения новой базы данных от сервера.
        /// </summary>
        public void Redraw()
        {
            lbCurrentDialog.Items.Clear();
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                foreach (Message message in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Messages)
                {
                    lbCurrentDialog.Items.Add(message.ToShortString());
                    lbCurrentDialog.ScrollIntoView(lbCurrentDialog.Items[lbCurrentDialog.Items.Count - 1]);
                }
            }

            lbDialogs.Items.Clear();
            ClientData.chats.Clear();
            foreach (Chat dialog in ClientData.database.Chats)
            {
                if (dialog.IsUserInChat(ClientData.CurrentUser))
                {
                    ClientData.chats.Add(dialog);
                    lbDialogs.Items.Add(dialog.Name);
                }
            }

            lbChatParticipant.Items.Clear();
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                foreach (User member in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Members)
                {
                    string str = "";
                    if (ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).RootID == member.ID)
                    {
                        str += "$  ";
                    }
                    else if (ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).IsUserInChatSilent(member.ID))
                    {
                        str += "</ ";
                    }
                    else
                    {
                        str += "<  ";
                    }
                    str += member.Nickname + " #" + member.ID;
                    lbChatParticipant.Items.Add(str);
                }
            }

            lbFile.Items.Clear();
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                List<string> files = ClientData.database.GetFilesFromDB(ClientData.CurrentUser.CurrentChatID);
                foreach (string file in files)
                {
                    lbFile.Items.Add(file);
                }
            }
        }

        /// <summary>
        /// Метод для получения базы данных от сервера.
        /// </summary>
        /// <param name="database"></param>
        public void DatabaseCallback(Database database)
        {
            int ID = -1;
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                ID = ClientData.CurrentUser.CurrentChatID;
            }
            ClientData.database.Update(database);
            if (ID != -1)
            {
                ClientData.CurrentUser.CurrentChatID = ID;
            }
            Redraw();
        }

        /// <summary>
        /// Метод для обработки события закрытия окна.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        public void WindowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ClientData.isClose)
            {
                Application.Current.Shutdown();
            }
            else
            {
                ClientData.isClose = true;
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Отправить сообщение".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickSendMessage(object sender, RoutedEventArgs e)
        {
            if (ClientData.client != null && ClientData.CurrentUser.CurrentChatID != -1 && tbMessage.Text != null && tbMessage.Text != "")
            {
                if (!ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).IsUserInChatSilent(ClientData.CurrentUser.ID))
                {
                    ClientData.client.GetMessageFromClient(ClientData.CurrentUser, tbMessage.Text, ClientData.CurrentUser.CurrentChatID);
                    tbMessage.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Профиль".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickProfile(object sender, RoutedEventArgs e)
        {
            SetButtonsHiddenAndDisabled();

            lbProfile.IsEnabled = true;
            lbProfile.Visibility = Visibility.Visible;
            bChangePassword.IsEnabled = true;
            bChangePassword.Visibility = Visibility.Visible;
            bExit.Visibility = Visibility.Visible;
            bExit.IsEnabled = true;
            lbProfile.Items.Clear();
            lbProfile.Items.Add("ID:\n" + ClientData.CurrentUser.ID + "\n");
            lbProfile.Items.Add("Name:\n" + ClientData.CurrentUser.Name + "\n");
            lbProfile.Items.Add("Surname:\n" + ClientData.CurrentUser.Surname + "\n");
            lbProfile.Items.Add("Nickname:\n" + ClientData.CurrentUser.Nickname + "\n");
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Участники чата".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickParticipian(object sender, RoutedEventArgs e)
        {
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                SetButtonsHiddenAndDisabled();

                bExitFromChat.IsEnabled = true;
                bExitFromChat.Visibility = Visibility.Visible;

                lbChatParticipant.IsEnabled = true;
                lbChatParticipant.Visibility = Visibility.Visible;

                lbChatParticipant.Items.Clear();
                if (ClientData.CurrentUser.CurrentChatID != -1)
                {
                    foreach (User member in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Members)
                    {
                        string str = "";
                        if (ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).RootID == member.ID)
                        {
                            str += "$  ";
                        }
                        else if (ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).IsUserInChatSilent(member.ID))
                        {
                            str += "</ ";
                        }
                        else
                        {
                            str += "<  ";
                        }
                        str += member.Nickname + " #" + member.ID;
                        lbChatParticipant.Items.Add(str);
                    }
                }
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Создать чат".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickNewChat(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpenCreateChat)
            {
                new CreateChat().Show();
                isWindowOpenCreateChat = true;
            }
            ButtonClickShowChats(sender, e);
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Изменить пароль".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickChangePassword(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpenChangePassword)
            {
                new ChangePasswordWindow().Show();
                isWindowOpenChangePassword = true;
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Список чатов".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickShowChats(object sender, RoutedEventArgs e)
        {
            SetButtonsHiddenAndDisabled();

            lbDialogs.IsEnabled = true;
            lbDialogs.Visibility = Visibility.Visible;

            lbDialogs.Items.Clear();
            ClientData.chats.Clear();
            foreach (Chat dialog in ClientData.database.Chats)
            {
                if (dialog.IsUserInChat(ClientData.CurrentUser))
                {
                    ClientData.chats.Add(dialog);
                    lbDialogs.Items.Add(dialog.Name);
                }
            }

        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Добавить пользователя".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickAddUser(object sender, RoutedEventArgs e)
        {
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                if (!isWindowOpenAddUser)
                {
                    new AddUserWindow().Show();
                    isWindowOpenAddUser = true;
                }
            }
        }

        /// <summary>
        /// Метод для обработки события выбора чата в списке чатов.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void SelectionDialog(object sender, RoutedEventArgs e)
        {
            lbCurrentDialog.Items.Clear();
            foreach (Chat dialog in ClientData.chats)
            {
                if (dialog.Name.Equals((String)lbDialogs.SelectedItem))
                {
                    ClientData.CurrentUser.CurrentChatID = dialog.ID;
                    lCurrentChatName.Content = ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Name;
                }
            }

            foreach (Message message in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Messages)
            {
                lbCurrentDialog.Items.Add(message.Date + " | " + message.Sender.Nickname + " |\n\t" + message.Text);
            }
            bAddUser.IsEnabled = true;
            bAddUser.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Показать файлы".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickShowFiles(object sender, RoutedEventArgs e)
        {
            SetButtonsHiddenAndDisabled();
            lbFile.Items.Clear();
            List<string> files = ClientData.database.GetFilesFromDB(ClientData.CurrentUser.CurrentChatID);
            foreach (string file in files)
            {
                lbFile.Items.Add(file);
            }
            lbFile.IsEnabled = true;
            lbFile.Visibility = Visibility.Visible;
            bSaveFile.Visibility = Visibility.Visible;
            bSaveFile.IsEnabled = true;
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Сохранить файл".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickSaveFile(object sender, RoutedEventArgs e)
        {
            lSavedFile.Visibility = Visibility.Visible;
            tbSavedFile.Text = "Файл сохранен в Dowloads";
            lSavedFile.IsEnabled = true;
            IrisLib.File file = new IrisLib.File();
            if (lbFile.SelectedItem != null)
            {
                file.Name = lbFile.SelectedItem.ToString();
                ClientData.client.GetFileFromHost(file.Name, ClientData.idOnServer, ClientData.CurrentUser.CurrentChatID);
            }
            else
            {
                tbSavedFile.Text = "Файл не выбран";
            }
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Отправить файл".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickSendFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
            }
            else
            {
                return;
            }

            System.IO.StreamReader streamReader;
            IrisLib.File file = new IrisLib.File();

            streamReader = new System.IO.StreamReader(dlg.FileName);
            FileStream stream = (FileStream)dlg.OpenFile();
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                file.Binary = memoryStream.ToArray();
                file.Name = dlg.FileName.Split(new char[] { '\\' })[dlg.FileName.Split(new char[] { '\\' }).Length - 1];
            }

            if (ClientData.database.GetFilesFromDB(ClientData.CurrentUser.CurrentChatID).Contains(file.Name))
            {
                tbSavedFile.Text = "Файл с таким именем уже существует";
                lSavedFile.Visibility = Visibility.Visible;
                return;
            }

            ButtonClickShowFiles(sender, e);
            streamReader.Close();

            ClientData.client.SendFileToHost(ClientData.CurrentUser, ClientData.CurrentUser.CurrentChatID, file);
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Покинуть чат".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickExitFromChat(object sender, RoutedEventArgs e)
        {
            lbCurrentDialog.Items.Clear();
            ButtonClickShowChats(sender, e);
            ClientData.client.RemoveUserFromChat(ClientData.CurrentUser.ID, ClientData.CurrentUser.CurrentChatID, false);
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Удалить пользователя из чата".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickRemoveUserFromChat(object sender, RoutedEventArgs e)
        {
            if (selectedUserID != -1 && ClientData.CurrentUser.ID != selectedUserID)
            {
                ClientData.client.RemoveUserFromChat(selectedUserID, ClientData.CurrentUser.CurrentChatID, true);
            }
            selectedUserID = -1;

            bRemoveUserFromChat.IsEnabled = false;
            bRemoveUserFromChat.Visibility = Visibility.Hidden;

            bMakeNotSilent.IsEnabled = false;
            bMakeNotSilent.Visibility = Visibility.Hidden;

            bMakeSilent.IsEnabled = false;
            bMakeSilent.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Заблокировать/разблокировать пользователя".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickMakeSilentOrNot(object sender, RoutedEventArgs e)
        {
            if (selectedUserID != -1 && ClientData.CurrentUser.ID != selectedUserID)
            {
                Chat currentChat = ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID);
                if (currentChat.IsUserInChatSilent(selectedUserID))
                {
                    ClientData.client.MakeUserInChatNotSilent(selectedUserID, currentChat.ID);
                }
                else
                {
                    ClientData.client.MakeUserInChatSilent(selectedUserID, currentChat.ID);
                }
            }
            selectedUserID = -1;

            bRemoveUserFromChat.IsEnabled = false;
            bRemoveUserFromChat.Visibility = Visibility.Hidden;

            bMakeNotSilent.IsEnabled = false;
            bMakeNotSilent.Visibility = Visibility.Hidden;

            bMakeSilent.IsEnabled = false;
            bMakeSilent.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод для обработки события выбора пользователя в списке участников чата.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void SelectionUser(object sender, RoutedEventArgs e)
        {
            if (lbChatParticipant.SelectedItem != null)
            {
                if (ClientData.CurrentUser.CurrentChatID != -1 &&
                        ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).RootID == ClientData.CurrentUser.ID)
                {
                    bRemoveUserFromChat.IsEnabled = true;
                    bRemoveUserFromChat.Visibility = Visibility.Visible;

                    string[] temp = lbChatParticipant.SelectedItem.ToString().Split(new char[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Int32.TryParse(temp[temp.Length - 1], out selectedUserID) && selectedUserID != ClientData.CurrentUser.ID)
                    {
                        Chat currentChat = ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID);
                        if (currentChat.IsUserInChatSilent(selectedUserID))
                        {
                            bMakeSilent.IsEnabled = false;
                            bMakeSilent.Visibility = Visibility.Hidden;
                            bMakeNotSilent.IsEnabled = true;
                            bMakeNotSilent.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            bMakeNotSilent.IsEnabled = false;
                            bMakeNotSilent.Visibility = Visibility.Hidden;
                            bMakeSilent.IsEnabled = true;
                            bMakeSilent.Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для сокрытия и дезактивации всех кнопок окна.
        /// </summary>
        private void SetButtonsHiddenAndDisabled()
        {
            lbDialogs.IsEnabled = false;
            lbDialogs.Visibility = Visibility.Hidden;

            lbChatParticipant.IsEnabled = false;
            lbChatParticipant.Visibility = Visibility.Hidden;

            lbProfile.IsEnabled = false;
            lbProfile.Visibility = Visibility.Hidden;

            bChangePassword.IsEnabled = false;
            bChangePassword.Visibility = Visibility.Hidden;

            bSaveFile.IsEnabled = false;
            bSaveFile.Visibility = Visibility.Hidden;

            lbFile.IsEnabled = false;
            lbFile.Visibility = Visibility.Hidden;

            lSavedFile.IsEnabled = false;
            lSavedFile.Visibility = Visibility.Hidden;

            bExit.IsEnabled = false;
            bExit.Visibility = Visibility.Hidden;

            bRemoveUserFromChat.IsEnabled = false;
            bRemoveUserFromChat.Visibility = Visibility.Hidden;

            bExitFromChat.IsEnabled = false;
            bExitFromChat.Visibility = Visibility.Hidden;

            bMakeNotSilent.IsEnabled = false;
            bMakeNotSilent.Visibility = Visibility.Hidden;

            bMakeSilent.IsEnabled = false;
            bMakeSilent.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Метод для получения файла с сервера.
        /// </summary>
        /// <param name="file"></param>
        public void FileCallback(IrisLib.File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Метод для получения идентификатора пользователя от сервера.
        /// </summary>
        /// <param name="id"></param>
        public void UserIdCallback(int id)
        {
            throw new NotImplementedException();
        }
    }
}
