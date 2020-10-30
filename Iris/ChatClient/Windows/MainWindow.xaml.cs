using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.ServiceChat;
using ChatClient.Windows;
using Iris;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        private bool isConnected;
        //public static User CurrentUser { get; set; }
        public static User CurrentUser;
        private List<Chat> chats;
        private ServiceChatClient client;
        int ID;

        public MainWindow()
        {
            InitializeComponent();
            client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            ID = client.Connect(CurrentUser.Nickname);
            CurrentUser.CurrentChat = null;
            chats = new List<Chat>();
            foreach (Chat dialog in Database.Chats)
            {

                if (dialog.Members.Contains(CurrentUser))
                {
                    chats.Add(dialog);
                    lbDialogs.Items.Add(dialog.Name);
                }
            }


            //temper
            Chat chat1 = new Chat(1, "427");
            lbDialogs.Items.Add(chat1.Name);
            chat1.Messages = new List<Message>();
            Chat chat2 = new Chat(2, "gay-club");
            lbDialogs.Items.Add(chat2.Name);
            chat2.Messages = new List<Message>();
            chat1.Messages.Add(new Message(100, new User(6, "loh", "loh", "loh", 22, "loh", "loh"), "Spartak sosat"));
            chat2.Messages.Add(new Message(101, new User(6, "loh", "loh", "loh", 22, "loh", "loh"), "Zenit onelove"));
            chat1.Messages.Add(new Message(102, CurrentUser, "i love deda"));
            chat2.Messages.Add(new Message(102, CurrentUser, "and dmitiy struckovsy"));

            chats.Add(chat1);
            chats.Add(chat2);

            CurrentUser.CurrentChat = chat1;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void MessageCallback(string message)
        {
            lbCurrentDialog.Items.Add(message);
            lbCurrentDialog.ScrollIntoView(lbCurrentDialog.Items[lbCurrentDialog.Items.Count - 1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //DisconnectUser();

        }

        private void Button_Click_SendMessage(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                client.SendMessage(tbMessage.Text, ID);
                tbMessage.Text = string.Empty;
            }
        }

        private void New_Dialog(object sender, RoutedEventArgs e)
        {
            new CreateChat().Show();
        }

        private void Button_Click_EditProfile(object sender, RoutedEventArgs e)
        {
            new EditProfile().Show();
            //this.Close();
        }

        private void Selection_Dialog(object sender, RoutedEventArgs e)
        {
            //todo: add exceptions (if currentChat == null will be bad)
            if (!((String)lbDialogs.SelectedItem).Equals(CurrentUser.CurrentChat.Name))
            {
                lbCurrentDialog.Items.Clear();
                foreach (Chat dialog in chats)
                {
                    if (dialog.Name.Equals((String)lbDialogs.SelectedItem))
                    {
                        CurrentUser.CurrentChat = dialog;
                    }
                }

                foreach (Message message in CurrentUser.CurrentChat.Messages)
                {
                    lbCurrentDialog.Items.Add(message.Sender.Nickname + " " + message.Text);
                }
            }
        }


        /*private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    
                    client.SendMessage(tbMessage.Text, ID);
                    tbMessage.Text = string.Empty;
                }
            }
        }*/


        //bool isConnected = false;
        //ServiceChatClient client;
        //int ID;

        //public MainWindow()
        //{
        //    InitializeComponent();
        //   // lbUserInfo.Items.Add(SignIn.user.Surname + " " + SignIn.user.Name);
        //    //lbUserInfo.Items.Add(SignIn.user.Nickname);

        //}

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //}

        ///*void ConnectUser()
        //{
        //    if (!isConnected)
        //    {
        //        client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
        //        ID = client.Connect(tbUserName.Text);
        //        tbUserName.IsEnabled = false;
        //        bConnectDisconnect.Content = "Disconnect";
        //        isConnected = true;
        //    }
        //}*/

        ///*void DisconnectUser()
        //{
        //    if (isConnected)
        //    {
        //        client.Disconnect(ID);
        //        client = null;
        //        tbUserName.IsEnabled = true;
        //        bConnectDisconnect.Content = "Connect";
        //        isConnected = false;
        //    }

        //}*/

        ///*private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (isConnected)
        //    {
        //        DisconnectUser();
        //    }
        //    else
        //    {
        //        ConnectUser();
        //    }

        //}*/

        //private void New_Dialog(object sender, RoutedEventArgs e)
        //{
        //    new CreateChat().Show();
        //}

        //private void Open_Dialog(object sender, RoutedEventArgs e)
        //{
        //    lbChat.Items.Add("dialog-=-\n");
        //}

        //public void MessageCallback(string message)
        //{
        //    lbChat.Items.Add(message);
        //    lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        //}

        //private void Button_Click_EditProfile(object sender, RoutedEventArgs e)
        //{
        //    new EditProfile().Show();
        //    //this.Close();
        //}

        ///*private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    DisconnectUser();
        //}*/

        ///*private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        if (client != null)
        //        {
        //            client.SendMessage(tbMessage.Text, ID);
        //            tbMessage.Text = string.Empty;
        //        }
        //    }
        //}*/


    }
}
