using IrisLib;
using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для CreateChat.xaml
    /// </summary>
    public partial class CreateChat : Window
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public CreateChat()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Назад".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Метод для обработки события нажания на кнопку "Добавить новый чат".
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void ButtonClickAddChat(object sender, RoutedEventArgs e)
        {
            foreach(Chat chat in ClientData.database.Chats)
            {
                if (chat.Name.Equals(tbChatName.Text))
                {
                    lableExistingChat.Visibility = Visibility.Visible;
                    return;
                }
            }
            Chat newChat = new Chat(0, tbChatName.Text);
            newChat.RootID = ClientData.CurrentUser.ID;
            newChat.Members.Add(ClientData.CurrentUser);
            ClientData.client.CreateNewChat(ClientData.CurrentUser, newChat);
            this.Close();
        }

        /// <summary>
        /// Метод для обработки события закрытия окна.
        /// </summary>
        /// <param name="sender"> объект, инициировавший событие </param>
        /// <param name="e"> аргумент, хранящий информацию о событии </param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenCreateChat = false;
        }
    }
}
