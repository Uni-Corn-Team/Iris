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
        public CreateChat()
        {
            InitializeComponent();
        }

        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenCreateChat = false;
        }
    }
}
