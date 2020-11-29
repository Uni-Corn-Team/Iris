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
using IrisClient.ServiceChat;
using IrisLib;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServerChatCallback
    {
        //private bool isConnected;
        //public static User CurrentUser { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //ClientData.client.Connect(ClientData.CurrentUser);
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

       
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void RedrawCurrentChat()
        {
            if (ClientData.CurrentUser.CurrentChatID != -1)
                lbCurrentDialog.Items.Clear();
                foreach (Message message in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Messages) 
                {
                    lbCurrentDialog.Items.Add(message);
                    lbCurrentDialog.ScrollIntoView(lbCurrentDialog.Items[lbCurrentDialog.Items.Count - 1]);
                }
        }

        void IServerChatCallback.DatabaseCallback(Database newDatabase)
        {
            /*
            if(ClientData.CurrentUser.CurrentChat != null)
            if(ClientData.CurrentUser.CurrentChat.ID == chatID)
            {
                lbCurrentDialog.Items.Add(message);
                lbCurrentDialog.ScrollIntoView(lbCurrentDialog.Items[lbCurrentDialog.Items.Count - 1]);
            }
            */
            int ID = -1;
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                ID = ClientData.CurrentUser.CurrentChatID;
            }
            ClientData.database.Update(newDatabase);
            if (ID != -1)
            {
                ClientData.CurrentUser.CurrentChatID = ID;
            }
            RedrawCurrentChat();
            /*
            foreach (Chat dialog in ClientData.database.Chats)
            {
                if (dialog.Members.Contains(ClientData.CurrentUser))
                {
                    ClientData.chats.Add(dialog);
                }
            }
            */
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClientData.client.Disconnect(ClientData.CurrentUser);
        }

        private void ButtonClickSendMessage(object sender, RoutedEventArgs e)
        {
            if (ClientData.client != null && ClientData.CurrentUser.CurrentChatID != -1 && tbMessage.Text != null && tbMessage.Text != "")
            {
                ClientData.client.GetMessageFromClient(ClientData.CurrentUser, tbMessage.Text, ClientData.CurrentUser.CurrentChatID);
                tbMessage.Text = string.Empty;
            }
        }

        private void NewDialog(object sender, RoutedEventArgs e)
        {
            new CreateChat().Show();
        }

        private void ButtonClickProfile(object sender, RoutedEventArgs e)
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
            lbProfile.Items.Add("ID:\n" + ClientData.CurrentUser.ID + "\n");
            lbProfile.Items.Add("Name:\n" + ClientData.CurrentUser.Name + "\n");
            lbProfile.Items.Add("Surname:\n" + ClientData.CurrentUser.Surname + "\n");
            lbProfile.Items.Add("Nickname:\n" + ClientData.CurrentUser.Nickname + "\n");
            //lbProfile.Items.Add("Login:\n" + CurrentUser.Login + "\n");
        }

        private void ButtonClickParticipian(object sender, RoutedEventArgs e)
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
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                foreach (User member in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Members)
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
            lbDialogs.IsEnabled = true;
            lbChatParticipant.IsEnabled = false;
            lbProfile.IsEnabled = false;
            lbDialogs.Visibility = Visibility.Visible;
            lbProfile.Visibility = Visibility.Hidden;
            lbChatParticipant.Visibility = Visibility.Hidden;
            bChangePassword.IsEnabled = false;
            bChangePassword.Visibility = Visibility.Hidden;
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
            lbDialogs.Visibility = Visibility.Visible;
           
        }
        private void ButtonClickAddUser(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().Show();
            this.Close();
        }

        private void SelectionDialog(object sender, RoutedEventArgs e)
        {
            //todo: add exceptions (if currentChat == null will be bad)
            //if (!((String)lbDialogs.SelectedItem).Equals(CurrentUser.CurrentChat.Name))
            //{
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

        //private void WindowLoaded(object sender, RoutedEventArgs e)
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

        //private void NewDialog(object sender, RoutedEventArgs e)
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

        ///*private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
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
