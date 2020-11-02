using Iris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatClient.Windows
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
            new MainWindow().Show();
            this.Close();
        }

        private void ButtonClickAddChat(object sender, RoutedEventArgs e)
        {
            Chat newChat = new Chat(/*Database.Chats.Last<Chat>().ID + 1*/0, tbChatName.Text);
            newChat.Members.Add(MainWindow.CurrentUser);
            Database.addChatToDB(newChat);
            MainWindow.CurrentUser.CurrentChat = Database.Chats.Last<Chat>();
            new MainWindow().Show();
            this.Close();
        }
    }
}
