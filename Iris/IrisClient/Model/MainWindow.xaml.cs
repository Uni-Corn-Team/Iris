using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Security.Policy;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.IO;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using IrisClient.ServiceChat;
using IrisLib;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ServiceChat.IServiceChatCallback
    {
        public static bool isWindowOpenChangePassword = false;
        public static bool isWindowOpenAddUSer = false;
        public static bool isWindowOpenCreateChat = false;
        private int selectedUserID = -1;
        
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

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            ClientData.CurrentUser = new User();
            ClientData.CurrentUser.ID = -1;
            ClientData.chats.Clear();
            new SignInWindow().Show();
            ClientData.isClose = false;
            this.Close();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        public void Redraw()
        {
            lbCurrentDialog.Items.Clear();
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                //lbCurrentDialog.Items.Clear();
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

            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                lbChatParticipant.Items.Clear();
                if (ClientData.CurrentUser.CurrentChatID != -1)
                {
                    foreach (User member in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Members)
                    {
                        lbChatParticipant.Items.Add(member.Nickname + " " + member.ID);
                    }
                }
            }
        }

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
        
        void WindowClosed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(ClientData.isClose)
                Application.Current.Shutdown();
            else
                ClientData.isClose = true;
        }

        /*public void IServerChatCallback.DatabaseCallback(Database database)
        {
       
//if(ClientData.CurrentUser.CurrentChat != null)
//if(ClientData.CurrentUser.CurrentChat.ID == chatID)
//{
//   lbCurrentDialog.Items.Add(message);
//   lbCurrentDialog.ScrollIntoView(lbCurrentDialog.Items[lbCurrentDialog.Items.Count - 1]);
//}

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
            RedrawCurrentChat();
            
            //foreach (Chat dialog in ClientData.database.Chats)
            //{
            //    if (dialog.Members.Contains(ClientData.CurrentUser))
            //    {
            //        ClientData.chats.Add(dialog);
            //    }
            //}
            
        }*/

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ClientData.client.Disconnect(ClientData.CurrentUser);
        }

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

        private void NewDialog(object sender, RoutedEventArgs e)
        {
            new CreateChat().Show();
        }

        private void ButtonClickProfile(object sender, RoutedEventArgs e)
        {
            // new ProfileWindow().Show();
            //this.Close();
            //need to do something with how it looks (now it's DISGUSTING!!!!)
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
            //lbProfile.Items.Add("Login:\n" + CurrentUser.Login + "\n");
        }

        private void ButtonClickParticipian(object sender, RoutedEventArgs e)
        {
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                SetButtonsHiddenAndDisabled();

                /*
                if (ClientData.CurrentUser.CurrentChatID != -1 &&
                    ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).RootID == ClientData.CurrentUser.ID)
                {
                    bRemoveUserFromChat.IsEnabled = true;
                    bRemoveUserFromChat.Visibility = Visibility.Visible;

                    bMakeSilentOrNot.IsEnabled = true;
                    bMakeSilentOrNot.Visibility = Visibility.Visible;
                }
                */

                bExitFromChat.IsEnabled = true;
                bExitFromChat.Visibility = Visibility.Visible;

                lbChatParticipant.IsEnabled = true;
                lbChatParticipant.Visibility = Visibility.Visible;

                lbChatParticipant.Items.Clear();
                if (ClientData.CurrentUser.CurrentChatID != -1)
                {
                    foreach (User member in ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).Members)
                    {
                        lbChatParticipant.Items.Add(member.Nickname + " " + member.ID);
                    }
                }
            }
        }

        private void ButtonClickNewChat(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpenCreateChat)
            {
                new CreateChat().Show();
                isWindowOpenCreateChat = true;
            }
            //this.Close();
        }

        private void ButtonClickChangePassword(object sender, RoutedEventArgs e)
        {
            if(!isWindowOpenChangePassword)
            {
                new ChangePasswordWindow().Show();
                isWindowOpenChangePassword = true;
            }
           //this.Close();
        }

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
        
        private void ButtonClickAddUser(object sender, RoutedEventArgs e)
        {
            if (ClientData.CurrentUser.CurrentChatID != -1)
            {
                if (!isWindowOpenAddUSer)
                {
                    new AddUserWindow().Show();
                    isWindowOpenAddUSer = true;
                }
            }
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

        private void ButtonClickShowFiles(object sender, RoutedEventArgs e)
        {
            SetButtonsHiddenAndDisabled();

            lbFile.IsEnabled = true;
            lbFile.Visibility = Visibility.Visible;
            bSaveFile.Visibility = Visibility.Visible;
            bSaveFile.IsEnabled = true;
        }

        private void ButtonClickSaveFile(object sender, RoutedEventArgs e)
        {
            lSavedFile.Visibility = Visibility.Visible;
            lSavedFile.IsEnabled = true;
        }

        private void ButtonClickSendFile(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            //dlg.FileName = "Document"; // Default file name
            // dlg.DefaultExt = ".txt"; // Default file extension
            //dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension


            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
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
            lbFile.Items.Clear();
            lbFile.Items.Add(streamReader.ReadToEnd());
            streamReader.Close();


            ClientData.client.SendFileToHost(ClientData.CurrentUser, ClientData.CurrentUser.CurrentChatID, file);
            /*lbDialogs.IsEnabled = false;
            lbChatParticipant.IsEnabled = false;
            lbProfile.IsEnabled = false;
            lbDialogs.Visibility = Visibility.Hidden;
            lbChatParticipant.Visibility = Visibility.Hidden;
            lbProfile.Visibility = Visibility.Hidden;
            lbFile.Visibility = Visibility.Visible;
            lbFile.IsEnabled = true;*/
        }

        private void ButtonClickExitFromChat(object sender, RoutedEventArgs e)
        {
            lbCurrentDialog.Items.Clear();
            ButtonClickShowChats(sender, e);
            ClientData.client.RemoveUserFromChat(ClientData.CurrentUser.ID, ClientData.CurrentUser.CurrentChatID);
        }

        private void ButtonClickRemoveUserFromChat(object sender, RoutedEventArgs e)
        {
            if (selectedUserID != -1 && ClientData.CurrentUser.ID != selectedUserID)
            {
                ClientData.client.RemoveUserFromChat(selectedUserID, ClientData.CurrentUser.CurrentChatID);
            }
            selectedUserID = -1;
        }

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
        }

        private void SelectionUser(object sender, RoutedEventArgs e)
        {
            if (lbChatParticipant.SelectedItem != null)
            {
                if (ClientData.CurrentUser.CurrentChatID != -1 &&
                        ClientData.database.GetChatFromList(ClientData.CurrentUser.CurrentChatID).RootID == ClientData.CurrentUser.ID)
                {
                    bRemoveUserFromChat.IsEnabled = true;
                    bRemoveUserFromChat.Visibility = Visibility.Visible;

                    string[] temp = lbChatParticipant.SelectedItem.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (Int32.TryParse(temp[temp.Length - 1], out selectedUserID))
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
