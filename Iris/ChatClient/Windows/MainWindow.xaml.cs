using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Security.Policy;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void MessageCallback(string message, int chatID)
        {
            if(CurrentUser.CurrentChat != null)
            if(CurrentUser.CurrentChat.ID == chatID)
            {
                lbCurrentDialog.Items.Add(message);
                lbCurrentDialog.ScrollIntoView(lbCurrentDialog.Items[lbCurrentDialog.Items.Count - 1]);
            }
            Database.getChatsFromDB();
            chats.Clear();
            foreach (Chat dialog in Database.Chats)
            {
                if (dialog.Members.Contains(CurrentUser))
                {
                    chats.Add(dialog);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Disconnect(ID);
        }

        private void Button_Click_SendMessage(object sender, RoutedEventArgs e)
        {
            if (client != null && CurrentUser.CurrentChat != null && tbMessage.Text != null)
            {
                Database.addMessageToChat(new Message(0, CurrentUser, tbMessage.Text), CurrentUser.CurrentChat);
                client.SendMessage(tbMessage.Text, ID, CurrentUser.CurrentChat.ID);
                //uncomment when ID are registered in the database
                //Database.getChatFromList(CurrentUser.CurrentChat.ID).Messages.Add(new Message(100, CurrentUser, tbMessage.Text));
                tbMessage.Text = string.Empty;
            }
        }

        private void New_Dialog(object sender, RoutedEventArgs e)
        {
            new CreateChat().Show();
        }

        private void Button_Click_Profile(object sender, RoutedEventArgs e)
        {
            // new ProfileWindow().Show();
            //this.Close();
            //need to do something with how it looks (now it's DISGUSTING!!!!)
            lbDialogs.IsEnabled = false;
            lbChatParticipant.IsEnabled = false;
            lbProfile.IsEnabled = true;
            lbDialogs.Visibility = Visibility.Hidden;
            lbChatParticipant.Visibility = Visibility.Hidden;
            lbProfile.Visibility = Visibility.Visible;
            bChangePassword.IsEnabled = true;
            bChangePassword.Visibility = Visibility.Visible;

            lbProfile.Items.Clear();
            lbProfile.Items.Add("ID:\n" + CurrentUser.ID + "\n");
            lbProfile.Items.Add("Name:\n" + CurrentUser.Name + "\n");
            lbProfile.Items.Add("Surname:\n" + CurrentUser.Surname + "\n");
            lbProfile.Items.Add("Nickname:\n" + CurrentUser.Nickname + "\n");
            lbProfile.Items.Add("Login:\n" + CurrentUser.Login + "\n");
        }

        private void Button_Click_Participian(object sender, RoutedEventArgs e)
        {
            lbDialogs.IsEnabled = false;
            lbChatParticipant.IsEnabled = true;
            lbProfile.IsEnabled = false;
            lbDialogs.Visibility = Visibility.Hidden;
            lbProfile.Visibility = Visibility.Hidden;
            lbChatParticipant.Visibility = Visibility.Visible;
            bChangePassword.IsEnabled = false;
            bChangePassword.Visibility = Visibility.Hidden;
            lbChatParticipant.Items.Clear();
            if (CurrentUser.CurrentChat != null)
            {
                foreach (User member in CurrentUser.CurrentChat.Members)
                {
                    lbChatParticipant.Items.Add(member.Nickname+" "+member.ID);
                }
            }
        }

        private void ButtonClickNewChat(object sender, RoutedEventArgs e)
        {
            new CreateChat().Show();
            this.Close();
        }

        private void ButtonClickChangePassword(object sender, RoutedEventArgs e)
        {
            new ChangePasswordWindow().Show();
            this.Close();
        }

        private void ButtonClickShowChats(object sender, RoutedEventArgs e)
        {
            Database.getChatsFromDB();
            lbDialogs.IsEnabled = true;
            lbChatParticipant.IsEnabled = false;
            lbProfile.IsEnabled = false;
            lbDialogs.Visibility = Visibility.Visible;
            lbProfile.Visibility = Visibility.Hidden;
            lbChatParticipant.Visibility = Visibility.Hidden;
            bChangePassword.IsEnabled = false;
            bChangePassword.Visibility = Visibility.Hidden;
            lbDialogs.Items.Clear();
            chats.Clear();
            foreach (Chat dialog in Database.Chats)
            {
                if (dialog.Members.Contains(CurrentUser))
                {
                    chats.Add(dialog);
                    lbDialogs.Items.Add(dialog.Name);
                }
            }
            lbDialogs.Visibility = Visibility.Visible;
           
        }
        private void ButtonClickAddUser(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
            this.Close();
        }

        private void Selection_Dialog(object sender, RoutedEventArgs e)
        {
            //todo: add exceptions (if currentChat == null will be bad)
            //if (!((String)lbDialogs.SelectedItem).Equals(CurrentUser.CurrentChat.Name))
            //{
                lbCurrentDialog.Items.Clear();
                foreach (Chat dialog in chats)
                {
                    if (dialog.Name.Equals((String)lbDialogs.SelectedItem))
                    {
                        CurrentUser.CurrentChat = dialog;
                        lCurrentChatName.Content = CurrentUser.CurrentChat.Name;
                    }
                }

                foreach (Message message in CurrentUser.CurrentChat.Messages)
                {
                    lbCurrentDialog.Items.Add(message.Sender.Nickname + " " + message.Text);
                }
            //}
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
