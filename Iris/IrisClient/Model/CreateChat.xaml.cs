using IrisLib;
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

namespace IrisClient
{
   
    /// <summary>
    /// Логика взаимодействия для CreateChat.xaml
    /// </summary>
    public partial class CreateChat : Window
    {
        private bool isShowNameChat = true;
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
            Chat newChat = new Chat(0, tbChatName.Text);
            newChat.Members.Add(ClientData.CurrentUser);
            ClientData.client.CreateNewChat(ClientData.CurrentUser, newChat);
            //возможно, нужно придумать переход на новый чат, но его еще нет в БД
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new MainWindow().Show();
          
        }

        private void RemoveTextNameChat(object sender, RoutedEventArgs e)
        {
            if(isShowNameChat)
            {
                tbChatName.Text = null;
                tbChatName.Foreground = Brushes.Black;
                isShowNameChat = false;
            }
        }
    }
}
