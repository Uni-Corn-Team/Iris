using IrisLib;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

namespace IrisClient
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private bool isShowID = true;
        
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

        private void RemoveTextID(object sender, EventArgs e)
        {
            if(isShowID)
            {
                tbID.Text = null;
                tbID.Foreground = Brushes.Black;
                isShowID = false;
            }
        }
        
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.isWindowOpenAddUSer = false;
        }

    }
}
