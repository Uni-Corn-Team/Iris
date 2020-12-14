using System;
using System.Windows;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickBack(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void ButtonClickAddUserToChat(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbID.Text, out int ID))
            {
                if (ClientData.database.GetUserFromList(ID) != null && ClientData.CurrentUser.CurrentChatID != -1)
                {
                    ClientData.client.AddUserToChat(ClientData.CurrentUser, ClientData.database.GetUserFromList(ID), ClientData.CurrentUser.CurrentChatID);
                    this.Close();
                }
                else
                {
                    lableNonexistingUser.Visibility = Visibility.Visible;
                    lableNotAnInteger.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                lableNotAnInteger.Visibility = Visibility.Visible;
                lableNonexistingUser.Visibility = Visibility.Hidden;
            }
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenAddUSer = false;
        }
    }
}
